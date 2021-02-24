using JetBrains.Annotations;
using DestinyCore.ETLDataCalculationTransMission.Shared;

namespace DestinyCore.ETLDataCalculationTransMission.MultiTenancy
{
    public interface ISuktConnectionStringResolver : IScopedDependency
    {
        [NotNull]
        string Resolve();
    }
}