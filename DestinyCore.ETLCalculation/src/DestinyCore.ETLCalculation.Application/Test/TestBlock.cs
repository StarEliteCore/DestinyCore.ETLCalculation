using DestinyCore.ETLCalculation.Dataflow;
using IDN.Service.ETLWorkFlow.Node.EntityFrameworkCore.SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.Application.Test
{
    public class TestBlock<T> : ITestBlock<T>
    {
        private readonly ISqlSugarDbContext _sqlSugarDbContext;

        public TestBlock(ISqlSugarDbContext sqlSugarDbContext)
        {
            _sqlSugarDbContext = sqlSugarDbContext;
        }

        public void Run()
        {

            ////AppDomain currentDomain;
            //AssemblyName myAssemblyName;
            //ModuleBuilder myMethodBuilder = null;
            //ILGenerator myILGenerator;
            //// Get the current application domain for the current thread.
            ////currentDomain = AppDomain.CurrentDomain;
            //myAssemblyName = new AssemblyName();
            //myAssemblyName.Name = "TempAssembly";
            //var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("TempAssembly"), AssemblyBuilderAccess.Run);
            //// Define a dynamic module in "TempAssembly" assembly.
            //myMethodBuilder = assemblyBuilder.DefineDynamicModule("TempModule");

            //// Define a global method in the 'TempModule' module.
            //myMethodBuilder = myModuleBuilder.DefineGlobalMethod
            //     ("MyMethod1", MethodAttributes.Static | MethodAttributes.Public,
            //           null, null);
            //myILGenerator = myMethodBuilder.GetILGenerator();
            //myILGenerator.EmitWriteLine("Hello World from global method.");
            //myILGenerator.Emit(OpCodes.Ret);
            //// Fix up the 'TempModule' module .
            //myModuleBuilder.CreateGlobalFunctions();

            var dbconntion = _sqlSugarDbContext.GetSqlSugarClient(new SqlSugar.ConnectionConfig()
            {
                ConnectionString = "server=10.1.40.207;userid=root;pwd=P@ssW0rd;database=IDN.DAS;connectiontimeout=3000;port=3306;Pooling=true;Max Pool Size=300; Maximum Pool Size=1000;",
                DbType = SqlSugar.DbType.MySql,
                IsAutoCloseConnection = true,
            });
            var downloadString = new TransformBlock<string, IDataFlowBuild<T>>(async uri =>
            {
                var dataFlowBuild = new DataFlowDefaultBuild<T>();
                var data = await dbconntion.Ado.SqlQueryAsync<T>($"SELECT information_schema.TABLES.TABLE_NAME FROM information_schema.TABLES  where information_schema.TABLES.TABLE_SCHEMA='IDN.DAS'  and information_schema.TABLES.TABLE_NAME='DataSource'");
                dataFlowBuild.CurrentData.Add("123456789", data);
                return dataFlowBuild;
            });
            //var createWordList = new TransformBlock<IDataFlowBuild<T>, IDataFlowBuild<T>>(text =>
            //{
            //    Console.WriteLine("Creating word list...");

            //    text.CurrentData.TryGetValue("123456789", out IEnumerable<T> list);
            //    var dataFlowBuild = new DataFlowDefaultBuild<T>();
            //    //dataFlowBuild.CurrentData=list.Where(x=>x.)
            //    return dataFlowBuild;
            //});
            var printReversedWords = new ActionBlock<IDataFlowBuild<T>>(reversedWord =>
            {
                Console.WriteLine("Creating word list...");
                reversedWord.CurrentData.TryGetValue("123456789", out IEnumerable<T> list);
                var dataFlowBuild = new DataFlowDefaultBuild<T>();
            });
            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            downloadString.LinkTo(printReversedWords, linkOptions);
            downloadString.Post("1111");
        }
    }
}
