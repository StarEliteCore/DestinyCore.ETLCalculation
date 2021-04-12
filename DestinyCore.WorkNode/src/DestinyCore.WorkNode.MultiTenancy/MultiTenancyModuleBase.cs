using Microsoft.Extensions.DependencyInjection;
using DestinyCore.WorkNode.Shared.Modules;

namespace DestinyCore.WorkNode.MultiTenancy
{
    public abstract class MultiTenancyModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddScoped<TenantInfo>();
        }
    }
}