using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using AzDoWebhooks.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using Azure.Identity;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;
using Microsoft.Azure.Functions.Worker.Http;
using System.Text.RegularExpressions;

namespace AzDoWebhooks.Functions;

public class NewDeployment
{
    private readonly ILogger<NewDeployment> _logger;
    private readonly IConfiguration _configuration;

    public NewDeployment(ILogger<NewDeployment> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [Function("NewDeployment")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
        [FromBody] DeploymentRequest deployRequest)
    {
        _logger.LogInformation("Received webhook request from Azure DevOps.");
        _logger.LogInformation(_configuration["CosmosDbConnection"]);

        string pattern = @"Deployment of release (?<ReleaseName>[\w-]+) on stage (?<StageName>\w+) (?<Status>\w+)\. Time to deploy: (?<DeployTime>\d+\.\d+) minutes\.";
        Match match = Regex.Match(deployRequest.DetailedMessage.Text, pattern);

        if (match.Success)
        {

            var releaseName = match.Groups["ReleaseName"].Value;
            var stageName = match.Groups["StageName"].Value;
            var status = match.Groups["Status"].Value;
            var deployTime = match.Groups["DeployTime"].Value;
            var projectId = deployRequest.ResourceContainers.Project.Id.ToString();

            DeploymentResponse deployment = new()
            {
                EventType = deployRequest.EventType,
                ReleaseName = releaseName,
                Environment = stageName,
                Status = status,
                DeploymentDateTime = deployRequest.CreatedDate.Date,
                DeploymentDuration = deployTime,
                Project = projectId,
                Message = deployRequest.DetailedMessage.Text,
                partitionKey = projectId
            };

            try
            {
                CosmosClient client = new(
                    accountEndpoint: _configuration["CosmosDbConnection"],
                    tokenCredential: new DefaultAzureCredential()
                );

                var database = client.GetDatabase("azdodeploy-db");
                var container = database.GetContainer("deployments");

                var response = await container.UpsertItemAsync<DeploymentResponse>(
                    item: deployment,
                    partitionKey: new PartitionKey(deployment.Project)
                );

                return new OkObjectResult($"Successfully added new deployment {deployment.id}");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while attempting to add {deploymentId}. {exceptionMessage}", deployment.id, ex.ToString());
            }
        }

        return new BadRequestResult();
    }
}

