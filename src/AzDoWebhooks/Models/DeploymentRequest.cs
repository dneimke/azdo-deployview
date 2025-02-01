namespace AzDoWebhooks.Models;

public class DeploymentRequest
{
    public string Environment { get; set; } = "";
    public string Project { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTime DeploymentTime { get; set; }
    public string partitionKey { get; set; } = "";
}