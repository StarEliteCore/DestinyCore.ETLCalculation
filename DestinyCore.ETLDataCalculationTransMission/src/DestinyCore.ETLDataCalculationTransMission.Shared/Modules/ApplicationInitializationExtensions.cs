using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLDataCalculationTransMission.Shared.SuktDependencyAppModule;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Modules
{
    public static class ApplicationInitializationExtensions
    {
        public static IApplicationBuilder GetApplicationBuilder(this ApplicationContext applicationContext)
        {
            return applicationContext.ServiceProvider.GetRequiredService<IObjectAccessor<IApplicationBuilder>>().Value;
        }
    }
}