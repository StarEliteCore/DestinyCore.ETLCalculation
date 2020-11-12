using MediatR;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using Destiny.Core.TaskScheduler.Shared.Modules;
using Destiny.Core.TaskScheduler.Shared.SuktReflection;

namespace Destiny.Core.TaskScheduler.Shared.Events
{
    public class EventBusAppModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var assemblys = service.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>()?.FindAll();
            service.AddMediatR(assemblys);
            service.AddEvents();
        }
    }
}