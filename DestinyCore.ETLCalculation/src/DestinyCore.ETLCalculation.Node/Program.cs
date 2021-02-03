using DestinyCore.ETLCalculation.Application.Test;
using DestinyCore.ETLCalculation.Node.Startups;
using DestinyCore.ETLCalculation.Shared.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System;

namespace DestinyCore.ETLCalculation.Node
{
    class Program
    {
        static void Main(string[] args)
        {

            IServiceCollection services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddDebug();
                builder.AddConsole();
            });
            services.AddApplication<SuktAppConsulModule>();
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(basePath));
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var Test = serviceProvider.GetService<ITestBlock>();
            Test.Run();
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
