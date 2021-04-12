using Microsoft.Extensions.DependencyInjection;
using DestinyCore.WorkNode.Shared.Modules;

namespace DestinyCore.WorkNode.CodeGenerator
{
    public class CodeGeneratorModeule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddSingleton<ICodeGenerator, RazorCodeGenerator>();
        }
    }
}