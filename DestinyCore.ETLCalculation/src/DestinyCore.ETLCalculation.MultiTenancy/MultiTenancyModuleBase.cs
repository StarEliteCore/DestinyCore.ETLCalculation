using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLCalculation.Shared.Modules;

namespace DestinyCore.ETLCalculation.MultiTenancy
{
    public abstract class MultiTenancyModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddScoped<TenantInfo>();
        }
    }
}