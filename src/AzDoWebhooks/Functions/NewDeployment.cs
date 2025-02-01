using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using AzDoWebhooks.Models;
using Microsoft.Extensions.Configuration;

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
    [CosmosDBOutput(databaseName: "azdodeploy-db", containerName: "deployments", Connection = "CosmosDbConnection", CreateIfNotExists = true)]
    public Deployment Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("Received webhook request from Azure DevOps.");
        _logger.LogInformation(_configuration["CosmosDbConnection"]);

        return new()
        {
            Environment = "Production",
            Status = "In Progress",
            DeploymentTime = DateTime.UtcNow,
            Project = "Contoso",
        };
    }
}

