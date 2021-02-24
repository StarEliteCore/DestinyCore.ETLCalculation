using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLDataCalculationTransMission.Shared.Modules;

namespace DestinyCore.ETLDataCalculationTransMission.MultiTenancy
{
    public abstract class MultiTenancyModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddScoped<TenantInfo>();
        }
    }
}