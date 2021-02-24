using System.Reflection;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.SuktReflection
{
    public class AssemblyFinder : FinderBase<Assembly>, IAssemblyFinder
    {
        protected override Assembly[] FindAllItems()
        {
            return AssemblyHelper.FindAllItems();
        }
    }
}