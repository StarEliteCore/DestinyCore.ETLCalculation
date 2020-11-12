using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.Shared.Modules;

namespace Destiny.Core.TaskScheduler.CodeGenerator
{
    public class CodeGeneratorModeule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddSingleton<ICodeGenerator, RazorCodeGenerator>();
        }
    }
}