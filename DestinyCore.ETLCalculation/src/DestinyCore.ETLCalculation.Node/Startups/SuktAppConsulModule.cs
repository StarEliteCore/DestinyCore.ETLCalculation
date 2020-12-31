using DestinyCore.ETLCalculation.Shared.Modules;
using DestinyCore.ETLCalculation.Shared.SuktDependencyAppModule;

namespace DestinyCore.ETLCalculation.Node.Startups
{
    [SuktDependsOn(
         typeof(DependencyAppModule)
         )]
    public class SuktAppConsulModule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {

        }

        public override void ApplicationInitialization(ApplicationContext context)
        {

        }
    }
}
