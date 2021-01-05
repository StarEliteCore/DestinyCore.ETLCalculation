using DestinyCore.ETLCalculation.Application.Connect;
using DestinyCore.ETLCalculation.Dtos.Decoder;
using DestinyCore.ETLCalculation.Node.Startups;
using DestinyCore.ETLCalculation.Shared.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SuperSocket.Client;
using SuperSocket.ProtoBase;
using System;
using System.Threading.Tasks;

namespace DestinyCore.ETLCalculation.Node
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddDebug();
                builder.AddConsole();
            });
            services.AddApplication<SuktAppConsulModule>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var _connect = serviceProvider.GetService<IConnectContract>();
            //初始化管道过滤器
            var pipelineFilter = new CommandLinePipelineFilter
            {
                Decoder = new DefaultStringPackageContract()
            };
            _connect.Client = new EasyClient<StringPackageInfo>(pipelineFilter).AsClient();
            await _connect.ConnectAsync();
            Console.WriteLine("Hello World!");
        }
    }
}
