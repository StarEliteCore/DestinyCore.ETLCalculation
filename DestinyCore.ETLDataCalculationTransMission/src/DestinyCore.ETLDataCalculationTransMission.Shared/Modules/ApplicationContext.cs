using DestinyCore.ETLDataCalculationTransMission.Shared.Extensions;
using DestinyCore.ETLDataCalculationTransMission.Shared.SuktDependencyAppModule;
using System;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Modules
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