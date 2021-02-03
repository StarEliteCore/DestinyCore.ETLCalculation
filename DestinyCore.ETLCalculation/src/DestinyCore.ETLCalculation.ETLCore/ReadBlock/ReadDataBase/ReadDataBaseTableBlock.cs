using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockOutputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using DestinyCore.ETLCalculation.ETLCore.Extensions;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.DestinyCoreBlock.ReadDataBase
{
    public class ReadDataBaseTableBlock<TInput> : IReadDataBaseTableBlock<TInput> where TInput : IBlockDataTableInputOption
    {
        public TransformBlock<TInput, IBlockOutputOption> GetTransformBlock()
        {
            return new TransformBlock<TInput, IBlockOutputOption>(async input =>
            {
                var result = new BlockOutputBaseOption();
                result.FlowId = input.FlowId;
                result.NodeId = input.NodeId;
                var data = await input.sqlSugarClient.Ado.GetDataTableAsync(input.ToSqlStr());
                result.Data.Add("123456", data);
                return result;
            });
        }
    }
}
