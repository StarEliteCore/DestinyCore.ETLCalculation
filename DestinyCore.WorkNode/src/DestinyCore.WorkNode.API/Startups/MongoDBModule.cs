using Microsoft.Extensions.DependencyInjection;
using DestinyCore.WorkNode.MongoDB;
using DestinyCore.WorkNode.MongoDB.DbContexts;
using DestinyCore.WorkNode.Shared.Extensions;

namespace DestinyCore.WorkNode.API.Startups
{
    public class MongoDBModule : MongoDBModuleBase
    {
        protected override void AddDbContext(IServiceCollection services)
        {
            //var dbpath = services.GetConfiguration()["SuktCore:DbContext:MongoDBConnectionString"];
            //var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            //var dbcontext = Path.Combine(basePath, dbpath);
            //if (!File.Exists(dbcontext))
            //{
            //    throw new Exception("未找到存放数据库链接的文件");
            //}
            var connection = services.GetFileByConfiguration("SuktCore:MongoDBs:MongoDBConnectionString", "未找到存放MongoDB数据库链接的文件"); //File.ReadAllText(dbcontext).Trim();
            services.AddMongoDbContext<DefaultMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });
        }
    }
}
