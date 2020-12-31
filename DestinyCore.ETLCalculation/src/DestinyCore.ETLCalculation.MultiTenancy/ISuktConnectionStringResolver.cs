using JetBrains.Annotations;
using DestinyCore.ETLCalculation.Shared;

namespace DestinyCore.ETLCalculation.MultiTenancy
{
    public interface ISuktConnectionStringResolver : IScopedDependency
    {
        [NotNull]
        string Resolve();
    }
}