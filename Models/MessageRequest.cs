using System.Text.Json.Serialization;

namespace Simplz.Europa.SafetyGateAlerts.Models;

public record MessageRequest(string Topic)
{
    [JsonPropertyName("topic")] public string Topic { get; set; } = Topic;
    [JsonPropertyName("message")] public string? Message { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("tags")] public List<string> Tags { get; } = [];
    public void AddTag(Emojis tag)
    {
        Tags.Add(tag.ToTag());
    }
    [JsonPropertyName("priority")] public Priority Priority { get; set; } = Priority.Default;
    [JsonPropertyName("actions")] public ActionRequest[]? Actions { get; set; }
    [JsonPropertyName("click")] public string? Click { get; set; }
    [JsonPropertyName("attach")] public string? Attach { get; set; }
    [JsonPropertyName("markdown")] public bool? Markdown { get; set; }
    [JsonPropertyName("icon")] public string? Icon { get; set; }
    [JsonPropertyName("filename")] public string? Filename { get; set; }
    [JsonPropertyName("delay")] public string? Delay { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("call")] public string? Call { get; set; }
}
