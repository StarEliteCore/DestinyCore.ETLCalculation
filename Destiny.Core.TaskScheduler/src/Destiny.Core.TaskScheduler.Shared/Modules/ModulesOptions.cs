using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.TaskScheduler.Shared.Modules
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