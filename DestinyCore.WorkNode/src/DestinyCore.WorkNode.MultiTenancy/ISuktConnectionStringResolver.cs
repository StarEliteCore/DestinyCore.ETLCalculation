using JetBrains.Annotations;
using DestinyCore.WorkNode.Shared;

namespace DestinyCore.WorkNode.MultiTenancy
{
    public interface ISuktConnectionStringResolver : IScopedDependency
    {
        [NotNull]
        string Resolve();
    }
}