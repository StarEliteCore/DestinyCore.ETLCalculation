using JetBrains.Annotations;
using DestinyCore.ETLDispatchCenter.Shared;

namespace DestinyCore.ETLDispatchCenter.MultiTenancy
{
    public interface ISuktConnectionStringResolver : IScopedDependency
    {
        [NotNull]
        string Resolve();
    }
}