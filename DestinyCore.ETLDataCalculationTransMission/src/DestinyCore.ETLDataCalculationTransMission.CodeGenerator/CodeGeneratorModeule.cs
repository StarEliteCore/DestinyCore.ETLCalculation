using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLDataCalculationTransMission.Shared.Modules;

namespace DestinyCore.ETLDataCalculationTransMission.CodeGenerator
{
    public class CodeGeneratorModeule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddSingleton<ICodeGenerator, RazorCodeGenerator>();
        }
    }
}