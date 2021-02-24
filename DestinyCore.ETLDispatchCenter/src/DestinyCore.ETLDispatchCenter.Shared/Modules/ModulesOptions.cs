using Microsoft.Extensions.DependencyInjection;

namespace DestinyCore.ETLDispatchCenter.Shared.Modules
{
    public class ModulesOptions
    {
        public IServiceCollection Service { get; }

        public ModulesOptions(IServiceCollection service)
        {
            Service = service;
        }
    }
}