using System.Text.Json;
using Microsoft.Extensions.Logging;
using Simplz.Europa.SafetyGateAlerts.Data;
using Simplz.Europa.SafetyGateAlerts.Models;

namespace Simplz.Europa.SafetyGateAlerts.Services;

public sealed class OpendatasoftClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<OpendatasoftClient> _logger;
    private readonly TimeProvider _timeProvider;
    private readonly HistoryContext _historyContext;

    public OpendatasoftClient(HttpClient httpClient, ILogger<OpendatasoftClient> logger, TimeProvider timeProvider, HistoryContext historyContext)
    {
        _httpClient = httpClient;
        _logger = logger;
        _timeProvider = timeProvider;
        _historyContext = historyContext;
    }

    public async Task ImportAsync()
    {
        int take = 20;
        int skip = 0;
        OpendatasoftResult? response = null;

        while (skip < (response?.TotalCount ?? 1))
        {
            response = await GetSafetyGateAlertsAsync(skip, take);
            await _historyContext.InsertOrUpdateAsync(response?.Results.Select(r => (HistoryItem)r).ToList() ?? []);
            skip += take;
        }
    }

    public async Task<OpendatasoftResult?> GetSafetyGateAlertsAsync(int skip, int take = 20)
    {
        string? content = null;
        HttpResponseMessage? httpResponseMessage = null;
        string url = $"healthref-europe-rapex-en/records?where=alert_date%20%3E%20'{_timeProvider.GetUtcNow():yyyy-01-01}'&order_by=modification_date%20ASC&limit={take}&offset={skip}";
        try
        {
            //where=alert_country%20%3D%20%27Cyprus%27
            httpResponseMessage = await _httpClient.GetAsync(url);
            content = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<OpendatasoftResult>(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting {Url} {StatusCode} {Content}", url, httpResponseMessage?.StatusCode, content);
            return null;
        }
    }
}
