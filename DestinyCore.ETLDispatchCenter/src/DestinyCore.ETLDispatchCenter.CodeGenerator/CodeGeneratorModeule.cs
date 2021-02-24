using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLDispatchCenter.Shared.Modules;

namespace DestinyCore.ETLDispatchCenter.CodeGenerator
{
    public class CodeGeneratorModeule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddSingleton<ICodeGenerator, RazorCodeGenerator>();
        }
    }
}