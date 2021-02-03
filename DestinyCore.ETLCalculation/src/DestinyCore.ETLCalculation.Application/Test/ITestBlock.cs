using DestinyCore.ETLCalculation.EntityFrameworkCore;
using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using DestinyCore.ETLCalculation.ETLCore.DestinyCoreBlock.ReadDataBase;
using DestinyCore.ETLCalculation.Shared;
using DestinyCore.ETLCalculation.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.Application.Test
{
    public interface ITestBlock : IScopedDependency
    {
        void Run();
    }
    public class TestBlock : ITestBlock
    {
        private readonly ISqlSugarDbContext _sqlSugarDbContext;
        private readonly IServiceProvider _serviceProvider;
        private readonly IReadDataBaseTableBlock<ReadDataBaseTableInputOption> _readDataBaseTableBlock;

        public TestBlock(ISqlSugarDbContext sqlSugarDbContext, IServiceProvider serviceProvider, IReadDataBaseTableBlock<ReadDataBaseTableInputOption> readDataBaseTableBlock)
        {
            _sqlSugarDbContext = sqlSugarDbContext;
            _serviceProvider = serviceProvider;
            _readDataBaseTableBlock = readDataBaseTableBlock;
        }

        public void Run()
        {
            //List<DataFlowNodeDto> nodes = new List<DataFlowNodeDto>()
            //{
            //    new DataFlowNodeDto(){NodeType=NodeTypeEnum.InputTable,Sort=0,Title="",},
            //    new DataFlowNodeDto(){NodeType=NodeTypeEnum.OutputExcel,Sort=0,Title="",},
            //};

            var connectionString = "SuktCoreDB.txt";
            if (Path.GetExtension(connectionString).ToLower() == ".txt") //txt文件
            {
                connectionString = _serviceProvider.GetFileText(connectionString, $"未找到存放{connectionString}数据库链接的文件");
            }
            var dbconntion = _sqlSugarDbContext.GetSqlSugarClient(new SqlSugar.ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true,
            });
            var input = _readDataBaseTableBlock.GetTransformBlock();
            var option = new ReadDataBaseTableInputOption()
            {
                sqlSugarClient = dbconntion,
                Column = new List<string>() { "WriteTime", "IpAddress", "Url", "Parameters", },
                TableName = "RecordOperationLog",
                NodeId = Guid.NewGuid(),
                FlowId = Guid.NewGuid(),
            };
            var tomongodb = new ActionBlock<IBlockOutputOption>(input =>
            {
                Console.WriteLine($"{input.FlowId}{input.Data}");
            });
            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            input.LinkTo(tomongodb, linkOptions);
            input.Post(option);
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





        }
    }
}
