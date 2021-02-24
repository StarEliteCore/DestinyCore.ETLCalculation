using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLDispatchCenter.Shared.Modules;

namespace DestinyCore.ETLDispatchCenter.MultiTenancy
{
    public abstract class MultiTenancyModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddScoped<TenantInfo>();
        }
    }
}