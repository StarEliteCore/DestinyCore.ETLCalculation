using DestinyCore.ETLCalculation.ETLCore;
using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using DestinyCore.ETLCalculation.ETLCore.DestinyCoreBlock.ReadData;
using DestinyCore.ETLCalculation.ETLCore.ReadBlock.CleanData;
using DestinyCore.ETLCalculation.ETLCore.ReadBlock.WriteData;
using DestinyCore.ETLCalculation.Shared;
using DestinyCore.ETLCalculation.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.Application.Test
{
    public interface ITestBlock : IScopedDependency
    {
        Task Run();
    }
    public class TestBlock : ITestBlock
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IReadSourceBlock _readSourceBlock;
        private readonly ITransFormBlock _transFormBlock;
        private readonly IWriteBlock _writeBlock;
        private IPropagatorBlock<string, IBlockOutputOption> _start;//开始的Block

        public TestBlock(IServiceProvider serviceProvider, IReadSourceBlock readSourceBlock, ITransFormBlock transFormBlock, IWriteBlock writeBlock)
        {
            _serviceProvider = serviceProvider;
            _readSourceBlock = readSourceBlock;
            _transFormBlock = transFormBlock;
            _writeBlock = writeBlock;
        }

        public async Task Run()
        {
            var degins = new FlowDto();
            var starts = GetStart(degins.Nodes);

            foreach (var item in starts)
            {
                var next = GetNext(degins, item.Id);
            }
            _start = await Builder();
            var connectionString = "SuktCoreDB.txt";
            if (Path.GetExtension(connectionString).ToLower() == ".txt") //txt文件
            {
                connectionString = _serviceProvider.GetFileText(connectionString, $"未找到存放{connectionString}数据库链接的文件");
            }
            var option = new ReadDataBaseTableInputOption()
            {
                NodeId = Guid.NewGuid(),
                FlowId = Guid.NewGuid(),
                Column = new List<string> { "WriteTime", "IpAddress", "Url", "Parameters" },
                TableName = "RecordOperationLog",
                ConnectionString = connectionString
            };
            var trans = _transFormBlock.TransForm();
            var write = await _writeBlock.SetDataBlock(option);
            _start.LinkTo(trans, new DataflowLinkOptions() { PropagateCompletion = true });
            trans.LinkTo(write, new DataflowLinkOptions() { PropagateCompletion = true });
            _start.Post("");
            _start.Complete();
            #region MyRegion
            //var dbconntion = _sqlSugarDbContext.GetSqlSugarClient(new SqlSugar.ConnectionConfig()
            //{
            //    ConnectionString = connectionString,
            //    DbType = SqlSugar.DbType.MySql,
            //    IsAutoCloseConnection = true,
            //});
            //var input = _readDataBaseTableBlock.GetTransformBlock();
            //var option = new ReadDataBaseTableInputOption()
            //{
            //    sqlSugarClient = dbconntion,
            //    Column = new List<string>() { "WriteTime", "IpAddress", "Url", "Parameters", },
            //    TableName = "RecordOperationLog",
            //    NodeId = Guid.NewGuid(),
            //    FlowId = Guid.NewGuid(),
            //};
            //var tomongodb = new ActionBlock<IBlockOutputOption>(input =>
            //{
            //    Console.WriteLine($"{input.FlowId}{input.Data}");
            //});
            //var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            //input.LinkTo(tomongodb, linkOptions);
            //input.Post(option);

            //var downloadString = new TransformBlock<string, IDataFlowData>(async uri =>
            //{
            //    var dataFlowBuild = new DataFlowDefaultBuild();
            //    Stopwatch stopwatch = new Stopwatch();
            //    stopwatch.Start();
            //    var data = await dbconntion.Ado.SqlQueryAsync<dynamic>($"SELECT * FROM OA_DailyWaitFill ");
            //    stopwatch.Stop();
            //    Console.WriteLine($"执行sql耗时：{stopwatch.ElapsedMilliseconds}");
            //    dataFlowBuild.Data.Add("123456789", data);
            //    return dataFlowBuild;
            //});
            //var printReversedWords = new ActionBlock<IBlockOutputOption>(input =>
            //{
            //    Console.WriteLine($"{input.FlowId}{input.Data}");
            //});

            //var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            //downloadString.LinkTo(printReversedWords, linkOptions);
            //downloadString.Post("1111");
            #endregion
        }
        public async Task<IPropagatorBlock<string, IBlockOutputOption>> Builder()
        {
            var connectionString = "SuktCoreDB.txt";
            if (Path.GetExtension(connectionString).ToLower() == ".txt") //txt文件
            {
                connectionString = _serviceProvider.GetFileText(connectionString, $"未找到存放{connectionString}数据库链接的文件");
            }
            var option = new ReadDataBaseTableInputOption()
            {
                NodeId = Guid.NewGuid(),
                FlowId = Guid.NewGuid(),
                Column = new List<string> { "WriteTime", "IpAddress", "Url", "Parameters" },
                TableName = "RecordOperationLog",
                ConnectionString = connectionString
            };
            return await _readSourceBlock.GetDataBlock(option);
        }


        public IEnumerable<DataFlowNodeDto> GetStart(List<DataFlowNodeDto> nodes)
        {
            return nodes.Where(x => x.NodeType == NodeTypeEnum.InputTable || x.NodeType == NodeTypeEnum.InputExcel);
        }
        public IEnumerable<DataFlowNodeDto> GetNext(FlowDto flow, Guid currennodeId)
        {
            var nextNodeId = flow.Edges.Where(x => x.Source.Cell == currennodeId).Select(x => x.Target.Cell);
            return flow.Nodes.Where(a => nextNodeId.Contains(a.Id));
        }
    }
}
