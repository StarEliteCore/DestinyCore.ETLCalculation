using DestinyCore.ETLCalculation.EntityFrameworkCore;
using DestinyCore.ETLCalculation.ETLCore.DataFlow;
using DestinyCore.ETLCalculation.Shared;
using DestinyCore.ETLCalculation.Shared.Extensions;
using IDN.Service.ETLWorkFlow.Node.Dtos.DataFlowDto;
using IDN.Service.ETLWorkFlow.Node.Dtos.DataFlowDto.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public TestBlock(ISqlSugarDbContext sqlSugarDbContext, IServiceProvider serviceProvider)
        {
            _sqlSugarDbContext = sqlSugarDbContext;
            _serviceProvider = serviceProvider;
        }

        public void Run()
        {
            List<DataFlowNodeDto> nodes = new List<DataFlowNodeDto>()
            {
                new DataFlowNodeDto(){NodeType=NodeTypeEnum.InputTable,Sort=0,Title="",},
                new DataFlowNodeDto(){NodeType=NodeTypeEnum.OutputExcel,Sort=0,Title="",},
            };
            try
            {
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
                }); ;
                var downloadString = new TransformBlock<string, IDataFlowData>(async uri =>
                {
                    var dataFlowBuild = new DataFlowDefaultBuild();
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var data = await dbconntion.Ado.SqlQueryAsync<dynamic>($"SELECT * FROM OA_DailyWaitFill ");
                    stopwatch.Stop();
                    Console.WriteLine($"执行sql耗时：{stopwatch.ElapsedMilliseconds}");
                    dataFlowBuild.Data.Add("123456789", data);
                    return dataFlowBuild;
                });
                var printReversedWords = new ActionBlock<IDataFlowData>(reversedWord =>
                {
                    Console.WriteLine("Creating word list...");
                    var dataFlowBuild = new DataFlowDefaultBuild();
                });
                var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
                downloadString.LinkTo(printReversedWords, linkOptions);
                downloadString.Post("1111");
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}
