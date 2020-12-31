using DestinyCore.ETLCalculation.Shared.Extensions;
using DestinyCore.ETLCalculation.Shared.SuktDependencyAppModule;
using System;

namespace DestinyCore.ETLCalculation.Shared.Modules
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