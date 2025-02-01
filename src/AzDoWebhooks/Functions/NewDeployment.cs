using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzDoWebhooks.Functions;

public class NewDeployment
{
    private readonly ILogger<NewDeployment> _logger;

    public NewDeployment(ILogger<NewDeployment> logger)
    {
        _logger = logger;
    }

    [Function("NewDeployment")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("Received webhook request from Azure DevOps.");
        return new OkObjectResult("Received webhook request from Azure DevOps.");
    }
}

