using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DestinyCore.ETLDataCalculationTransMission.Shared.Events.EventBus;
using DestinyCore.ETLDataCalculationTransMission.Shared.Extensions;
using DestinyCore.ETLDataCalculationTransMission.Shared.Modules;
using DestinyCore.ETLDataCalculationTransMission.Shared.SuktReflection;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Events
{
    public class EventBusAppModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var assemblys = service.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>()?.FindAll();
            service.AddMediatR(assemblys);
            service.TryAddTransient<IMediatorHandler, InMemoryDefaultBus>();//事件总线需要使用瞬时注入，否则在过滤器内无法获取当前字典
        }
    }
}
