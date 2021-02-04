using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using DestinyCore.ETLCalculation.Shared;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.ReadBlock.CleanData
{
    public interface ITransFormBlock : IScopedDependency
    {
        IPropagatorBlock<IBlockOutputOption, IBlockOutputOption> TransForm();
    }
}
