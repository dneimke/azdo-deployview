using System.Text.Json;
using Microsoft.Azure.Functions.Worker;

namespace AzDoWebhooks.Models;


public class DeploymentResponse
{
    [CosmosDBOutput(
                databaseName: "ToDoItems",
                containerName: "Items",
                Connection = "CosmosDBConnection")]
    public Deployment? Deployment { get; set; }
}
public class Deployment
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string Environment { get; set; } = "";
    public string Project { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTime DeploymentTime { get; set; }
    public string partitionKey { get; set; } = "";
}