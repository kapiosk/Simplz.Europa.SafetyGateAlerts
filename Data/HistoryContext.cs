using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Simplz.Europa.SafetyGateAlerts.Models;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Result>().HasKey(x => x.RapexUrl);
    }

    public DbSet<Result> Results => Set<Result>();

    public void InsertOrUpdate(List<Result> newResults)
    {
        try
        {
            this.BulkInsertOrUpdate(newResults);
            this.BulkSaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inserting or updating {Count} results", newResults.Count);
        }
    }
}
