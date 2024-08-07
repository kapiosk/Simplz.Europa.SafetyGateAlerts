namespace Simplz.Europa.SafetyGateAlerts.Extensions;

public sealed class ManualTimeProvider : TimeProvider
{
    private readonly TimeSpan _diff;

    public ManualTimeProvider(TimeSpan diff)
    {
        _diff = diff;
    }

    public override DateTimeOffset GetUtcNow()
    {
        return base.GetUtcNow() + _diff;
    }
}
