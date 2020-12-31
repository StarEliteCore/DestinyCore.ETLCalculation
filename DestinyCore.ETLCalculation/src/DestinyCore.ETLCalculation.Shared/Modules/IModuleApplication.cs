using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.Shared.Modules
{
    public interface IModuleApplication : IDisposable
    {
        Type StartupModuleType { get; }
        IServiceCollection Services { get; }

        IServiceProvider ServiceProvider { get; }

        IReadOnlyList<ISuktAppModule> Modules { get; }
    }
}