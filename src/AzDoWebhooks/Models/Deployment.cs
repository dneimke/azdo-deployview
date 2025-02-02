namespace AzDoWebhooks.Models;

public class DeploymentResponse
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string Environment { get; set; } = "";
    public string Project { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTime DeploymentTime { get; set; }
    public string partitionKey { get; set; } = "";
}