namespace AzDoWebhooks.Models;

public class DeploymentResponse
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string EventType { get; set; } = "";
    public string ReleaseName { get; set; } = "";
    public string Environment { get; set; } = "";
    public string Project { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTime DeploymentDateTime { get; set; }
    public string DeploymentDuration { get; set; } = "";
    public string Message { get; set; } = "";
    public string partitionKey { get; set; } = "";
}