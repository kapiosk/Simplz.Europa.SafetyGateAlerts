using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Simplz.Europa.SafetyGateAlerts.Data;
using Simplz.Europa.SafetyGateAlerts.Extensions;
using Simplz.Europa.SafetyGateAlerts.Services;

ServiceCollection services = new();

services.AddSingleton<TimeProvider>(sp => new ManualTimeProvider(TimeSpan.Zero));

services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Warning);
});

services.AddDbContext<HistoryContext>();

services.AddHttpClient<NtfyClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://ntfy.sh");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
});

services.AddHttpClient<OpendatasoftClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://public.opendatasoft.com/api/explore/v2.1/catalog/datasets/");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
});

await using ServiceProvider serviceProvider = services.BuildServiceProvider();

await serviceProvider.GetRequiredService<OpendatasoftClient>().ImportAsync();
