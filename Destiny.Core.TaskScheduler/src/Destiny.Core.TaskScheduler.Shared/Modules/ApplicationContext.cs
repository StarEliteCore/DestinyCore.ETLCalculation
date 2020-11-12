using Destiny.Core.TaskScheduler.Shared.Extensions;
using Destiny.Core.TaskScheduler.Shared.SuktDependencyAppModule;
using System;

namespace Destiny.Core.TaskScheduler.Shared.Modules
{
    /// <summary>
    /// 自定义应用上下文
    /// </summary>
    public class ApplicationContext : IServiceProviderAccessor
    {
        public ApplicationContext(IServiceProvider serviceProvider)
        {
            serviceProvider.NotNull(nameof(serviceProvider));
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; set; }
    }
}