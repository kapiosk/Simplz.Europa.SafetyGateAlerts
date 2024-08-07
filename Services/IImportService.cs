using Simplz.Europa.SafetyGateAlerts.Data;

namespace Simplz.Europa.SafetyGateAlerts.Services;

public interface IImportService
{
    Task<List<HistoryItem>> ImportAsync();
}
