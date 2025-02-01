using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzDoWebhooks.Functions;

public class HttpEcho(ILogger<HttpEcho> logger)
{
    private readonly ILogger<HttpEcho> _logger = logger;

    [Function("HttpEcho")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("HttpEcho function processed a request.");
        return new OkObjectResult("Welcome to AzDo Webhooks!");
    }
}
