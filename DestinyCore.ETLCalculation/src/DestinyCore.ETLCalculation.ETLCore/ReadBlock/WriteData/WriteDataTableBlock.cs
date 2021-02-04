using DestinyCore.ETLCalculation.EntityFrameworkCore;
using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using SqlSugar;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.ReadBlock.WriteData
{
    public class WriteDataTableBlock : IWriteBlock
    {
        private readonly ISqlSugarDbContext _sqlSugarDbContext;

        public WriteDataTableBlock(ISqlSugarDbContext sqlSugarDbContext)
        {
            _sqlSugarDbContext = sqlSugarDbContext;
        }
        public NodeTypeEnum NodeType => NodeTypeEnum.OutputTable;

        public async Task<ITargetBlock<IBlockOutputOption>> SetDataBlock(IBlockDataTableInputOption option)
        {
            await Task.CompletedTask;
            var dbconn = _sqlSugarDbContext.GetSqlSugarClient(new ConnectionConfig() { ConnectionString = option.ConnectionString, DbType = DbType.MySql, IsAutoCloseConnection = true });
            var actionBlock = new ActionBlock<IBlockOutputOption>(input =>
            {
                Console.WriteLine("写数据到数据仓库等等");
                Console.WriteLine(input.FlowId);
            }/*, new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = _maxDegreeOfParallelism}*/);

            return actionBlock;
        }
    }
}
