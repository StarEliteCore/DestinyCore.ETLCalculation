using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using DestinyCore.ETLCalculation.ETLCore.ReadBlock;
using DestinyCore.ETLCalculation.Shared;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.DestinyCoreBlock.ReadDataBase
{
    public interface IReadDataBaseTableBlock<TInput> : IReadBlock, IScopedDependency where TInput : IBlockDataTableInputOption
    {
        TransformBlock<TInput, IBlockOutputOption> GetTransformBlock();
    }
}
