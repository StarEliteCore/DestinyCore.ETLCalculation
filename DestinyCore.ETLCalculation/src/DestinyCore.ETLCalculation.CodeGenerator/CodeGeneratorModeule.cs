using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLCalculation.Shared.Modules;

namespace DestinyCore.ETLCalculation.CodeGenerator
{
    public class CodeGeneratorModeule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddSingleton<ICodeGenerator, RazorCodeGenerator>();
        }
    }
}