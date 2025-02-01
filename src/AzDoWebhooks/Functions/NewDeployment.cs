using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using AzDoWebhooks.Models;

namespace AzDoWebhooks.Functions;

public class NewDeployment
{
    private readonly ILogger<NewDeployment> _logger;

    public NewDeployment(ILogger<NewDeployment> logger)
    {
        _logger = logger;
    }

    [Function("NewDeployment")]
    [CosmosDBOutput(databaseName: "azdodeploy-db", containerName: "deployments", Connection = "CosmosDbConnection", CreateIfNotExists = true)]
    public Deployment Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("Received webhook request from Azure DevOps.");

        return new()
        {
            Environment = "Production",
            Status = "In Progress",
            DeploymentTime = DateTime.UtcNow,
            Project = "Contoso",
        };
    }
}

