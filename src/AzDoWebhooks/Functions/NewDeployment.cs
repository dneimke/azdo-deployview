using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using AzDoWebhooks.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using Azure.Identity;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

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
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
        [FromBody] DeploymentRequest azureDeployment)
    {
        _logger.LogInformation("Received webhook request from Azure DevOps.");
        _logger.LogInformation(_configuration["CosmosDbConnection"]);

        CosmosClient client = new(
            accountEndpoint: _configuration["CosmosDbConnection"],
            tokenCredential: new DefaultAzureCredential()
        );

        var database = client.GetDatabase("azdodeploy-db");
        var container = database.GetContainer("deployments");

        Deployment deployment = new()
        {
            Environment = azureDeployment.Environment,
            Status = azureDeployment.Status,
            DeploymentTime = azureDeployment.DeploymentTime,
            Project = azureDeployment.Project,
            partitionKey = azureDeployment.Project
        };

        try
        {
            var response = await container.UpsertItemAsync<Deployment>(
                item: deployment,
                partitionKey: new PartitionKey(deployment.Project)
            );
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while attempting to add {deploymentId}. {exceptionMessage}", deployment.id, ex.ToString());
        }


        return new OkObjectResult($"Successfully added new deployment {deployment.id}");
    }
}

