using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.Shared.Modules;

namespace Destiny.Core.TaskScheduler.MultiTenancy
{
    public abstract class MultiTenancyModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddScoped<TenantInfo>();
        }
    }
}