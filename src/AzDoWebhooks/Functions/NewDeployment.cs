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
        var cosmosEndpoint = _configuration["CosmosDbConnection"];
        var cosmosDatabase = _configuration["CosmosDatabaseName"];
        var cosmosContainer = _configuration["CosmosContainerName"];

        _logger.LogInformation("Received webhook request from Azure DevOps.");
        _logger.LogInformation("Cosmos endpoint: {cosmosEndpoint}; database: {cosmosDatabase}; container: {cosmosContainer}",
                               cosmosEndpoint,
                               cosmosDatabase,
                               cosmosContainer);

        string pattern = @"Deployment of release (?<ReleaseNumber>[\w-]+) on stage (?<StageName>[\w\s]+) (?<Status>\w+)\. Time to deploy: (?:(?<DeployTimeMinutes>\d+\.\d+) minutes\.|(?<DeployTime>[\d:]+))\.";
        Match match = Regex.Match(deployRequest.DetailedMessage.Text, pattern);

        if (!match.Success)
        {
            _logger.LogWarning("{messageText} did not match the expected pattern.", deployRequest.DetailedMessage.Text);
            return new BadRequestObjectResult(new { error = "Invalid input data." });
        }

        _logger.LogInformation("Started processing. Mapping inputs to output POCO");

        DeploymentResponse deployment = new();

        try
        {
            var releaseNumber = match.Groups["ReleaseNumber"].Value;
            var stageName = match.Groups["StageName"].Value;
            var status = match.Groups["Status"].Value;
            var deployTime = match.Groups["DeployTime"].Value;
            var projectName = deployRequest.Resource.Project.Name;
            var releasePipeline = deployRequest.Resource.Environment.ReleaseDefinition.Name;
            var partitionKey = $"{releasePipeline}-{stageName}";

            deployment = new()
            {
                EventType = deployRequest.EventType,
                ReleasePipeline = releasePipeline,
                ReleaseNumber = releaseNumber,
                Environment = stageName,
                Stage = stageName,
                Status = status,
                DeploymentDateTime = deployRequest.CreatedDate.DateTime,
                DeploymentDuration = deployTime,
                Project = projectName,
                Message = deployRequest.DetailedMessage.Text
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while mapping inputs to outputs. Aborting processing.");
        }



        _logger.LogInformation("Completed mapping inputs to output POCO");

        try
        {
            CosmosClient client = new(
                accountEndpoint: cosmosEndpoint,
                tokenCredential: new DefaultAzureCredential()
            );

            var database = client.GetDatabase(cosmosDatabase);
            var container = database.GetContainer(cosmosContainer);

            var response = await container.CreateItemAsync(
                item: deployment,
                partitionKey: new PartitionKey(deployment.ReleasePipeline)
            );

            _logger.LogInformation("Successfully added new deployment {deploymentId}", deployment.id);

            return new OkObjectResult(new
            {
                message = $"Successfully added new deployment {deployment.id}",
                data = new
                {
                    AzDoDeploymentId = deployRequest.Id,
                    CosmosDeploymentId = deployment.id
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "An error occurred while attempting to add {deploymentId} with partitionKey {partitionKey}. {exceptionMessage}",
                deployment.id,
                deployment.ReleasePipeline,
                ex.ToString()
                );
        }

        return new StatusCodeResult(500);
    }
}

