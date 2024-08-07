using System.Text.Json.Serialization;

namespace Simplz.Europa.SafetyGateAlerts.Models;

public record ActionRequest(string Action, string Label, string Url)
{
    [JsonPropertyName("action")] public string Action { get; set; } = Action;
    [JsonPropertyName("label")] public string Label { get; set; } = Label;
    [JsonPropertyName("url")] public string Url { get; set; } = Url;
    [JsonPropertyName("clear")] public bool? Clear { get; set; }
}
