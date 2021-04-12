using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DestinyCore.WorkNode.Shared.Events.EventBus;
using DestinyCore.WorkNode.Shared.Extensions;
using DestinyCore.WorkNode.Shared.Modules;
using DestinyCore.WorkNode.Shared.SuktReflection;

namespace DestinyCore.WorkNode.Shared.Events
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
