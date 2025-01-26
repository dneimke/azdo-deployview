using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzDo.DevOps.WebHooks
{
    public class AzDevOpsWebHook
    {
        private readonly ILogger<AzDevOpsWebHook> _logger;

        public AzDevOpsWebHook(ILogger<AzDevOpsWebHook> logger)
        {
            _logger = logger;
        }

        [Function("AzDevOpsWebHook")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
