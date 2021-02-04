using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using DestinyCore.ETLCalculation.Shared;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.ReadBlock.WriteData
{
    public interface IWriteBlock : IScopedDependency
    {
        /// <summary>
        /// 节点处理类型
        /// </summary>
        NodeTypeEnum NodeType { get; }
        /// <summary>
        /// 数据传输
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        Task<ITargetBlock<IBlockOutputOption>> SetDataBlock(IBlockDataTableInputOption option);
    }
}
