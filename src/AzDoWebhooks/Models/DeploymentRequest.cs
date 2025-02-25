using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace AzDoWebhooks.Models;

// <auto-generated />
// https://app.quicktype.io/
//
// To parse this JSON data, add NuGet 'System.Text.Json' then do:
//
//    using AzDoWebhooks.Models;
//
//    var deployment = DeploymentRequest.FromJson(jsonString);
#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8603


public partial class DeploymentRequest
{
    [JsonPropertyName("subscriptionId")]
    public Guid SubscriptionId { get; set; }

    [JsonPropertyName("notificationId")]
    public long NotificationId { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("eventType")]
    public string EventType { get; set; }

    [JsonPropertyName("publisherId")]
    public string PublisherId { get; set; }

    [JsonPropertyName("message")]
    public Message Message { get; set; }

    [JsonPropertyName("detailedMessage")]
    public Message DetailedMessage { get; set; }

    [JsonPropertyName("resource")]
    public Resource Resource { get; set; }

    [JsonPropertyName("resourceVersion")]
    public string ResourceVersion { get; set; }

    [JsonPropertyName("resourceContainers")]
    public ResourceContainers ResourceContainers { get; set; }

    [JsonPropertyName("createdDate")]
    public DateTimeOffset CreatedDate { get; set; }
}

public partial class Message
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}

public partial class Resource
{
    [JsonPropertyName("environment")]
    public Environment Environment { get; set; }

    [JsonPropertyName("project")]
    public Project Project { get; set; }

    [JsonPropertyName("deployment")]
    public Deployment Deployment { get; set; }

    [JsonPropertyName("comment")]
    public object Comment { get; set; }

    [JsonPropertyName("data")]
    public Data Data { get; set; }

    [JsonPropertyName("stageName")]
    public string StageName { get; set; }

    [JsonPropertyName("attemptId")]
    public long AttemptId { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }
}

public partial class Data
{
    [JsonPropertyName("releaseProperties")]
    public string ReleaseProperties { get; set; }

    [JsonPropertyName("environmentStatuses")]
    public string EnvironmentStatuses { get; set; }

    [JsonPropertyName("workItems")]
    public object[] WorkItems { get; set; }

    [JsonPropertyName("previousReleaseEnvironment")]
    public PreviousReleaseEnvironment PreviousReleaseEnvironment { get; set; }

    [JsonPropertyName("commits")]
    public object[] Commits { get; set; }

    [JsonPropertyName("testResults")]
    public TestResults TestResults { get; set; }

    [JsonPropertyName("moreWorkItemsMessage")]
    public string MoreWorkItemsMessage { get; set; }
}

public partial class PreviousReleaseEnvironment
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public partial class TestResults
{
}

public partial class Deployment
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("release")]
    public PurpleRelease Release { get; set; }

    [JsonPropertyName("releaseDefinition")]
    public ReleaseDefinition ReleaseDefinition { get; set; }

    [JsonPropertyName("releaseEnvironment")]
    public DeploymentReleaseEnvironment ReleaseEnvironment { get; set; }

    [JsonPropertyName("projectReference")]
    public object ProjectReference { get; set; }

    [JsonPropertyName("definitionEnvironmentId")]
    public long DefinitionEnvironmentId { get; set; }

    [JsonPropertyName("attempt")]
    public long Attempt { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }

    [JsonPropertyName("deploymentStatus")]
    public string DeploymentStatus { get; set; }

    [JsonPropertyName("operationStatus")]
    public string OperationStatus { get; set; }

    [JsonPropertyName("requestedBy")]
    public RequestedBy RequestedBy { get; set; }

    [JsonPropertyName("requestedFor")]
    public RequestedBy RequestedFor { get; set; }

    [JsonPropertyName("queuedOn")]
    public DateTimeOffset QueuedOn { get; set; }

    [JsonPropertyName("startedOn")]
    public DateTimeOffset StartedOn { get; set; }

    [JsonPropertyName("completedOn")]
    public DateTimeOffset CompletedOn { get; set; }

    [JsonPropertyName("lastModifiedOn")]
    public DateTimeOffset LastModifiedOn { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public LastModifiedBy LastModifiedBy { get; set; }

    [JsonPropertyName("conditions")]
    public Condition[] Conditions { get; set; }

    [JsonPropertyName("preDeployApprovals")]
    public DeployApproval[] PreDeployApprovals { get; set; }

    [JsonPropertyName("postDeployApprovals")]
    public DeployApproval[] PostDeployApprovals { get; set; }

    [JsonPropertyName("_links")]
    public TestResults Links { get; set; }
}

public partial class Condition
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("conditionType")]
    public string ConditionType { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("result")]
    public bool Result { get; set; }
}

public partial class LastModifiedBy
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("uniqueName")]
    public string UniqueName { get; set; }

    [JsonPropertyName("descriptor")]
    public string Descriptor { get; set; }
}

public partial class DeployApproval
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("revision")]
    public long Revision { get; set; }

    [JsonPropertyName("approvalType")]
    public string ApprovalType { get; set; }

    [JsonPropertyName("createdOn")]
    public DateTimeOffset CreatedOn { get; set; }

    [JsonPropertyName("modifiedOn")]
    public DateTimeOffset ModifiedOn { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("comments")]
    public string Comments { get; set; }

    [JsonPropertyName("isAutomated")]
    public bool IsAutomated { get; set; }

    [JsonPropertyName("isNotificationOn")]
    public bool IsNotificationOn { get; set; }

    [JsonPropertyName("trialNumber")]
    public long TrialNumber { get; set; }

    [JsonPropertyName("attempt")]
    public long Attempt { get; set; }

    [JsonPropertyName("rank")]
    public long Rank { get; set; }

    [JsonPropertyName("release")]
    public ReleaseDefinitionClass Release { get; set; }

    [JsonPropertyName("releaseDefinition")]
    public ReleaseDefinitionClass ReleaseDefinition { get; set; }

    [JsonPropertyName("releaseEnvironment")]
    public ReleaseDefinitionClass ReleaseEnvironment { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }
}

public partial class ReleaseDefinitionClass
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("_links")]
    public TestResults Links { get; set; }

    [JsonPropertyName("projectReference")]
    public object ProjectReference { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("path")]
    public string Path { get; set; }
}

public partial class PurpleRelease
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("artifacts")]
    public object[] Artifacts { get; set; }

    [JsonPropertyName("webAccessUri")]
    public Uri WebAccessUri { get; set; }

    [JsonPropertyName("_links")]
    public PurpleLinks Links { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }
}

public partial class PurpleLinks
{
    [JsonPropertyName("self")]
    public Logs Self { get; set; }

    [JsonPropertyName("web")]
    public Logs Web { get; set; }

    [JsonPropertyName("logs")]
    public Logs Logs { get; set; }
}

public partial class Logs
{
    [JsonPropertyName("href")]
    public Uri Href { get; set; }
}

public partial class ReleaseDefinition
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("projectReference")]
    public Project ProjectReference { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("_links")]
    public ReleaseDefinitionLinks Links { get; set; }
}

public partial class ReleaseDefinitionLinks
{
    [JsonPropertyName("web")]
    public Logs Web { get; set; }

    [JsonPropertyName("self")]
    public Logs Self { get; set; }
}

public partial class Project
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public partial class DeploymentReleaseEnvironment
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("_links")]
    public ReleaseDefinitionLinks Links { get; set; }
}

public partial class RequestedBy
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("_links")]
    public RequestedByLinks Links { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("uniqueName")]
    public string UniqueName { get; set; }

    [JsonPropertyName("imageUrl")]
    public Uri ImageUrl { get; set; }

    [JsonPropertyName("descriptor")]
    public string Descriptor { get; set; }
}

public partial class RequestedByLinks
{
    [JsonPropertyName("avatar")]
    public Logs Avatar { get; set; }
}

public partial class Environment
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("releaseId")]
    public long ReleaseId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("variables")]
    public TestResults Variables { get; set; }

    [JsonPropertyName("variableGroups")]
    public object[] VariableGroups { get; set; }

    [JsonPropertyName("preDeployApprovals")]
    public DeployApproval[] PreDeployApprovals { get; set; }

    [JsonPropertyName("postDeployApprovals")]
    public DeployApproval[] PostDeployApprovals { get; set; }

    [JsonPropertyName("preApprovalsSnapshot")]
    public ApprovalsSnapshot PreApprovalsSnapshot { get; set; }

    [JsonPropertyName("postApprovalsSnapshot")]
    public ApprovalsSnapshot PostApprovalsSnapshot { get; set; }

    [JsonPropertyName("deploySteps")]
    public DeployStep[] DeploySteps { get; set; }

    [JsonPropertyName("rank")]
    public long Rank { get; set; }

    [JsonPropertyName("definitionEnvironmentId")]
    public long DefinitionEnvironmentId { get; set; }

    [JsonPropertyName("environmentOptions")]
    public EnvironmentOptions EnvironmentOptions { get; set; }

    [JsonPropertyName("demands")]
    public object[] Demands { get; set; }

    [JsonPropertyName("conditions")]
    public Condition[] Conditions { get; set; }

    [JsonPropertyName("createdOn")]
    public DateTimeOffset CreatedOn { get; set; }

    [JsonPropertyName("modifiedOn")]
    public DateTimeOffset ModifiedOn { get; set; }

    [JsonPropertyName("workflowTasks")]
    public object[] WorkflowTasks { get; set; }

    [JsonPropertyName("deployPhasesSnapshot")]
    public DeployPhasesSnapshot[] DeployPhasesSnapshot { get; set; }

    [JsonPropertyName("owner")]
    public RequestedBy Owner { get; set; }

    [JsonPropertyName("schedules")]
    public object[] Schedules { get; set; }

    [JsonPropertyName("release")]
    public DeploymentReleaseEnvironment Release { get; set; }

    [JsonPropertyName("releaseDefinition")]
    public ReleaseDefinition ReleaseDefinition { get; set; }

    [JsonPropertyName("releaseCreatedBy")]
    public RequestedBy ReleaseCreatedBy { get; set; }

    [JsonPropertyName("triggerReason")]
    public string TriggerReason { get; set; }

    [JsonPropertyName("timeToDeploy")]
    public double TimeToDeploy { get; set; }

    [JsonPropertyName("processParameters")]
    public TestResults ProcessParameters { get; set; }

    [JsonPropertyName("preDeploymentGatesSnapshot")]
    public DeploymentGatesSnapshot PreDeploymentGatesSnapshot { get; set; }

    [JsonPropertyName("postDeploymentGatesSnapshot")]
    public DeploymentGatesSnapshot PostDeploymentGatesSnapshot { get; set; }
}

public partial class DeployPhasesSnapshot
{
    [JsonPropertyName("deploymentInput")]
    public DeploymentInput DeploymentInput { get; set; }

    [JsonPropertyName("rank")]
    public long Rank { get; set; }

    [JsonPropertyName("phaseType")]
    public string PhaseType { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("refName")]
    public object RefName { get; set; }

    [JsonPropertyName("workflowTasks")]
    public object[] WorkflowTasks { get; set; }
}

public partial class DeploymentInput
{
    [JsonPropertyName("parallelExecution")]
    public ParallelExecution ParallelExecution { get; set; }

    [JsonPropertyName("agentSpecification")]
    public object AgentSpecification { get; set; }

    [JsonPropertyName("skipArtifactsDownload")]
    public bool SkipArtifactsDownload { get; set; }

    [JsonPropertyName("artifactsDownloadInput")]
    public ArtifactsDownloadInput ArtifactsDownloadInput { get; set; }

    [JsonPropertyName("queueId")]
    public long QueueId { get; set; }

    [JsonPropertyName("demands")]
    public object[] Demands { get; set; }

    [JsonPropertyName("enableAccessToken")]
    public bool EnableAccessToken { get; set; }

    [JsonPropertyName("timeoutInMinutes")]
    public long TimeoutInMinutes { get; set; }

    [JsonPropertyName("jobCancelTimeoutInMinutes")]
    public long JobCancelTimeoutInMinutes { get; set; }

    [JsonPropertyName("condition")]
    public string Condition { get; set; }

    [JsonPropertyName("overrideInputs")]
    public TestResults OverrideInputs { get; set; }
}

public partial class ArtifactsDownloadInput
{
    [JsonPropertyName("downloadInputs")]
    public object[] DownloadInputs { get; set; }
}

public partial class ParallelExecution
{
    [JsonPropertyName("parallelExecutionType")]
    public string ParallelExecutionType { get; set; }
}

public partial class DeployStep
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("deploymentId")]
    public long DeploymentId { get; set; }

    [JsonPropertyName("attempt")]
    public long Attempt { get; set; }

    [JsonPropertyName("reason")]
    public string Reason { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("operationStatus")]
    public string OperationStatus { get; set; }

    [JsonPropertyName("releaseDeployPhases")]
    public ReleaseDeployPhase[] ReleaseDeployPhases { get; set; }

    [JsonPropertyName("requestedBy")]
    public RequestedBy RequestedBy { get; set; }

    [JsonPropertyName("requestedFor")]
    public RequestedBy RequestedFor { get; set; }

    [JsonPropertyName("queuedOn")]
    public DateTimeOffset QueuedOn { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public LastModifiedBy LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedOn")]
    public DateTimeOffset LastModifiedOn { get; set; }

    [JsonPropertyName("hasStarted")]
    public bool HasStarted { get; set; }

    [JsonPropertyName("tasks")]
    public object[] Tasks { get; set; }

    [JsonPropertyName("runPlanId")]
    public Guid RunPlanId { get; set; }

    [JsonPropertyName("issues")]
    public object[] Issues { get; set; }
}

public partial class ReleaseDeployPhase
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("phaseId")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long PhaseId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("rank")]
    public long Rank { get; set; }

    [JsonPropertyName("phaseType")]
    public string PhaseType { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("runPlanId")]
    public Guid RunPlanId { get; set; }

    [JsonPropertyName("deploymentJobs")]
    public DeploymentJob[] DeploymentJobs { get; set; }

    [JsonPropertyName("manualInterventions")]
    public object[] ManualInterventions { get; set; }

    [JsonPropertyName("startedOn")]
    public DateTimeOffset StartedOn { get; set; }
}

public partial class DeploymentJob
{
    [JsonPropertyName("job")]
    public Job Job { get; set; }

    [JsonPropertyName("tasks")]
    public Job[] Tasks { get; set; }
}

public partial class Job
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("timelineRecordId")]
    public Guid TimelineRecordId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("dateStarted")]
    public DateTimeOffset DateStarted { get; set; }

    [JsonPropertyName("dateEnded")]
    public DateTimeOffset DateEnded { get; set; }

    [JsonPropertyName("startTime")]
    public DateTimeOffset StartTime { get; set; }

    [JsonPropertyName("finishTime")]
    public DateTimeOffset FinishTime { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("rank")]
    public long Rank { get; set; }

    [JsonPropertyName("issues")]
    public object[] Issues { get; set; }

    [JsonPropertyName("agentName")]
    public string AgentName { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("task")]
    public Task Task { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("percentComplete")]
    public long? PercentComplete { get; set; }
}

public partial class Task
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }
}

public partial class EnvironmentOptions
{
    [JsonPropertyName("emailNotificationType")]
    public string EmailNotificationType { get; set; }

    [JsonPropertyName("emailRecipients")]
    public string EmailRecipients { get; set; }

    [JsonPropertyName("skipArtifactsDownload")]
    public bool SkipArtifactsDownload { get; set; }

    [JsonPropertyName("timeoutInMinutes")]
    public long TimeoutInMinutes { get; set; }

    [JsonPropertyName("enableAccessToken")]
    public bool EnableAccessToken { get; set; }

    [JsonPropertyName("publishDeploymentStatus")]
    public bool PublishDeploymentStatus { get; set; }

    [JsonPropertyName("badgeEnabled")]
    public bool BadgeEnabled { get; set; }

    [JsonPropertyName("autoLinkWorkItems")]
    public bool AutoLinkWorkItems { get; set; }

    [JsonPropertyName("pullRequestDeploymentEnabled")]
    public bool PullRequestDeploymentEnabled { get; set; }
}

public partial class ApprovalsSnapshot
{
    [JsonPropertyName("approvals")]
    public object[] Approvals { get; set; }
}

public partial class DeploymentGatesSnapshot
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("gatesOptions")]
    public object GatesOptions { get; set; }

    [JsonPropertyName("gates")]
    public object[] Gates { get; set; }
}

public partial class ResourceContainers
{
    [JsonPropertyName("collection")]
    public Account Collection { get; set; }

    [JsonPropertyName("account")]
    public Account Account { get; set; }

    [JsonPropertyName("project")]
    public Account Project { get; set; }
}

public partial class Account
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("baseUrl")]
    public Uri BaseUrl { get; set; }
}

public partial class DeploymentRequest
{
    public static DeploymentRequest FromJson(string json) => JsonSerializer.Deserialize<DeploymentRequest>(json, AzDoWebhooks.Models.Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this DeploymentRequest self) => JsonSerializer.Serialize(self, AzDoWebhooks.Models.Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
    {
        Converters =
            {
                new DateOnlyConverter(),
                new TimeOnlyConverter(),
                IsoDateTimeOffsetConverter.Singleton
            },
    };
}

internal class ParseStringConverter : JsonConverter<long>
{
    public override bool CanConvert(Type t) => t == typeof(long);

    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        long l;
        if (Int64.TryParse(value, out l))
        {
            return l;
        }
        throw new Exception("Cannot unmarshal type long");
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.ToString(), options);
        return;
    }

    public static readonly ParseStringConverter Singleton = new ParseStringConverter();
}

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    private readonly string serializationFormat;
    public DateOnlyConverter() : this(null) { }

    public DateOnlyConverter(string? serializationFormat)
    {
        this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
    }

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return DateOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
}

public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    private readonly string serializationFormat;

    public TimeOnlyConverter() : this(null) { }

    public TimeOnlyConverter(string? serializationFormat)
    {
        this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
    }

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return TimeOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
}

internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

    private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

    private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
    private string? _dateTimeFormat;
    private CultureInfo? _culture;

    public DateTimeStyles DateTimeStyles
    {
        get => _dateTimeStyles;
        set => _dateTimeStyles = value;
    }

    public string? DateTimeFormat
    {
        get => _dateTimeFormat ?? string.Empty;
        set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
    }

    public CultureInfo Culture
    {
        get => _culture ?? CultureInfo.CurrentCulture;
        set => _culture = value;
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        string text;


        if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
        {
            value = value.ToUniversalTime();
        }

        text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

        writer.WriteStringValue(text);
    }

    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? dateText = reader.GetString();

        if (string.IsNullOrEmpty(dateText) == false)
        {
            if (!string.IsNullOrEmpty(_dateTimeFormat))
            {
                return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
            }
            else
            {
                return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
            }
        }
        else
        {
            return default(DateTimeOffset);
        }
    }


    public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
}

#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603
