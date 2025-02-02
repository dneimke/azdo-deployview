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

        DeploymentResponse deployment = new()
        {
            Environment = azureDeployment.SubscriptionId.ToString(),
            Status = azureDeployment.EventType,
            DeploymentTime = azureDeployment.CreatedDate.Date,
            Project = azureDeployment.Message.Text,
            partitionKey = azureDeployment.Message.Text
        };

        try
        {
            var response = await container.UpsertItemAsync<DeploymentResponse>(
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

