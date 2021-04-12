using Microsoft.Extensions.DependencyInjection;

namespace DestinyCore.WorkNode.Shared.Modules
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