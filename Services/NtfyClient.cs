using System.Net.Http.Json;
using Simplz.Europa.SafetyGateAlerts.Models;

namespace Simplz.Europa.SafetyGateAlerts.Services;

public class NtfyClient
{
    private readonly HttpClient _httpClient;

    public NtfyClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendMessageAsync(MessageRequest messageRequest, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync($"https://ntfy.sh", messageRequest, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
