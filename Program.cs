using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Simplz.Europa.SafetyGateAlerts.Data;
using Simplz.Europa.SafetyGateAlerts.Extensions;
using Simplz.Europa.SafetyGateAlerts.Models;
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

services.AddHttpClient<IImportService, OpendatasoftClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://public.opendatasoft.com/api/explore/v2.1/catalog/datasets/");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
});

// services.AddScoped(sp =>
// {
//     return new InfluxDB3.Client.InfluxDBClient(Environment.GetEnvironmentVariable("INFLUXDB_URL"));
// });

using var serviceScope = services.BuildServiceProvider().CreateScope();
using var historyContext = serviceScope.ServiceProvider.GetRequiredService<HistoryContext>();
await historyContext.Database.MigrateAsync();

var ntfyClient = serviceScope.ServiceProvider.GetRequiredService<NtfyClient>();

foreach (var importService in serviceScope.ServiceProvider.GetServices<IImportService>())
{
    var itemsToBeNotified = await importService.ImportAsync();
    var topic = Environment.GetEnvironmentVariable("EUROPA_NTFY_TOPIC");
    var contains = Environment.GetEnvironmentVariable("EUROPA_CONTAINS");
    if (!string.IsNullOrEmpty(topic) && !string.IsNullOrEmpty(contains))
        foreach (var item in itemsToBeNotified.Where(x => x.Data.Contains(contains, StringComparison.OrdinalIgnoreCase)))
        {
            MessageRequest messageRequest = new(topic)
            {
                Title = item.Title,
                Message = item.Description,
                Click = item.Url,
            };
            await ntfyClient.SendMessageAsync(messageRequest);
        }
}
