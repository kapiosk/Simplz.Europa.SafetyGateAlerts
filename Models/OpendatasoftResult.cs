using System.Text.Json.Serialization;

namespace Simplz.Europa.SafetyGateAlerts.Models;

public sealed record OpendatasoftResult
{
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }

    [JsonPropertyName("results")]
    public List<Result> Results { get; set; } = [];
}
