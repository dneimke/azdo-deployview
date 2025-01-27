using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzDoWebhooks;

public class Functions(ILogger<Functions> logger)
{
    private readonly ILogger<Functions> _logger = logger;

    [FunctionName("HttpExample")]
    public IActionResult HttpExample([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }

    [FunctionName("AzureDevOpsWebhook")]
    public IActionResult AzureDevOpsWebhook([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
    {
        _logger.LogInformation("Received webhook request from Azure DevOps.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
