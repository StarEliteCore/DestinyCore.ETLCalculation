using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.TaskScheduler.Shared.Modules
{
    /// <summary>
    ///
    /// </summary>
    public interface IStartupModuleRunner : IModuleApplication
    {
        void ConfigureServices(IServiceCollection services);

        void Initialize(IServiceProvider service);
    }
}