using System.Net;
using Microsoft.EntityFrameworkCore;
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

services.AddHttpClient<IImportService, OpendatasoftClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://public.opendatasoft.com/api/explore/v2.1/catalog/datasets/");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
});

using var serviceScope = services.BuildServiceProvider().CreateScope();
using var historyContext = serviceScope.ServiceProvider.GetRequiredService<HistoryContext>();
await historyContext.Database.MigrateAsync();

foreach (var importService in serviceScope.ServiceProvider.GetServices<IImportService>())
{
    var itemsToBeNotified = await importService.ImportAsync();
    //Get config for service from historyContext
    //var ntfyClient = serviceScope.ServiceProvider.GetRequiredService<NtfyClient>();
}
