using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DestinyCore.WorkNode.Shared.SuktDependencyAppModule;

namespace DestinyCore.WorkNode.Shared.Modules
{
    public static class ApplicationInitializationExtensions
    {
        public static IApplicationBuilder GetApplicationBuilder(this ApplicationContext applicationContext)
        {
            return applicationContext.ServiceProvider.GetRequiredService<IObjectAccessor<IApplicationBuilder>>().Value;
        }
    }
}