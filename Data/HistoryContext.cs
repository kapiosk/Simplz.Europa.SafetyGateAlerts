using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Simplz.Europa.SafetyGateAlerts.Data;

public sealed class HistoryContext : DbContext
{
    //Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
    private static string DbPath { get => Path.Join(Environment.CurrentDirectory, "History.sqlite"); }

    private readonly ILogger<HistoryContext> _logger;
    // dotnet ef migrations add InitialCreate
    // dotnet ef database update
    public HistoryContext(ILogger<HistoryContext> logger)
    {
        _logger = logger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public DbSet<HistoryItem> HistoryItems => Set<HistoryItem>();

    public async Task InsertOrUpdateAsync(List<HistoryItem> newItems)
    {
        try
        {
            foreach (var newItem in newItems)
            {
                var existing = await HistoryItems.FirstOrDefaultAsync(i => i.Id == newItem.Id);
                if (existing is not null)
                {
                    if (newItem.UpdatedAt >= existing.UpdatedAt)
                    {
                        existing.Data = newItem.Data;
                        existing.UpdatedAt = newItem.UpdatedAt;
                        existing.Title = newItem.Title;
                        existing.Description = newItem.Description;
                        existing.Url = newItem.Url;
                        HistoryItems.Update(existing);
                    }
                }
                else
                {
                    await HistoryItems.AddAsync(newItem);
                }
                await SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inserting or updating {Count} results", newItems.Count);
        }
    }
}
