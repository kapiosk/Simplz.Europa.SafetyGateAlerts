namespace Simplz.Europa.SafetyGateAlerts.Data;

public sealed record HistoryItem(string Id, string Data, DateTime UpdatedAt)
{
    public string Id { get; init; } = Id;
    public string Data { get; set; } = Data;
    public DateTime UpdatedAt { get; set; } = UpdatedAt;
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
}
