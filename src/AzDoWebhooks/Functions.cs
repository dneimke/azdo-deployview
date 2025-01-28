using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzDoWebhooks;

public class Functions(ILogger<Functions> logger)
{
    private readonly ILogger<Functions> _logger = logger;

    [Function("HttpEcho")]
    public IActionResult HttpEcho([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("HttpEcho function processed a request.");
        return new OkObjectResult("Welcome to AzDo Webhooks!");
    }

    [Function("AzDoReleaseWebhook")]
    public IActionResult AzDoReleaseWebhook([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
    {
        _logger.LogInformation("Received webhook request from Azure DevOps.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
