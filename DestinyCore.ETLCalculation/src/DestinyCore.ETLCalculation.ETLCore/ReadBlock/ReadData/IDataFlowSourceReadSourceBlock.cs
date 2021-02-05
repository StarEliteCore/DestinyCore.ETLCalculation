using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using DestinyCore.ETLCalculation.Shared;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.DestinyCoreBlock.ReadData
{
    public interface IDataFlowSourceReadSourceBlock<TOutput> : IDataFlowSource<TOutput>, IScopedDependency
    {
        /// <summary>
        /// 数据传输
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        Task<IPropagatorBlock<string, TOutput>> GetDataBlock(IBlockDataTableInputOption option);
    }
}
