using DestinyCore.ETLCalculation.EntityFrameworkCore;
using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockOutputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using DestinyCore.ETLCalculation.ETLCore.Extensions;
using SqlSugar;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.DestinyCoreBlock.ReadData
{
    public class ReadDataTableBlock : IReadSourceBlock
    {
        private readonly ISqlSugarDbContext _sqlSugarDbContext;

        public ReadDataTableBlock(ISqlSugarDbContext sqlSugarDbContext, IServiceProvider serviceProvider)
        {
            _sqlSugarDbContext = sqlSugarDbContext;
        }

        public NodeTypeEnum NodeType => NodeTypeEnum.InputTable;

        public async Task<IPropagatorBlock<string, IBlockOutputOption>> GetDataBlock(IBlockDataTableInputOption option)
        {
            await Task.CompletedTask;
            var nextBlock = new BufferBlock<IBlockOutputOption>();
            var result = new BlockOutputBaseOption();
            result.FlowId = option.FlowId;
            result.NodeId = option.NodeId;
            var getDataTableBlock = new ActionBlock<string>(async x =>
           {
               var dbconn = _sqlSugarDbContext.GetSqlSugarClient(new ConnectionConfig() { ConnectionString = option.ConnectionString, DbType = DbType.MySql, IsAutoCloseConnection = true });
               Stopwatch stopwatch = new Stopwatch();
               stopwatch.Start();
               var data = await dbconn.Ado.GetDataTableAsync(option.ToSqlStr());
               stopwatch.Stop();
               Console.WriteLine($"执行sql耗时：{stopwatch.ElapsedMilliseconds}");
               result.Data.Add("123456", data);
               Console.WriteLine("将数据库数据读取出，并发送到下一步");
               nextBlock.Post(result);
           }/*, new ExecutionDataflowBlockOptions{MaxDegreeOfParallelism = _maxDegreeOfParallelism}*/);
            return DataflowBlock.Encapsulate(getDataTableBlock, nextBlock);
        }
    }
}
