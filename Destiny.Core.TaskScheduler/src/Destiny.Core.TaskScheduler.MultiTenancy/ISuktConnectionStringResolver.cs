using JetBrains.Annotations;
using Destiny.Core.TaskScheduler.Shared;

namespace Destiny.Core.TaskScheduler.MultiTenancy
{
    public interface ISuktConnectionStringResolver : IScopedDependency
    {
        [NotNull]
        string Resolve();
    }
}