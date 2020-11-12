using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.Shared.SuktDependencyAppModule;

namespace Destiny.Core.TaskScheduler.Shared.Modules
{
    public static class ApplicationInitializationExtensions
    {
        public static IApplicationBuilder GetApplicationBuilder(this ApplicationContext applicationContext)
        {
            return applicationContext.ServiceProvider.GetRequiredService<IObjectAccessor<IApplicationBuilder>>().Value;
        }
    }
}