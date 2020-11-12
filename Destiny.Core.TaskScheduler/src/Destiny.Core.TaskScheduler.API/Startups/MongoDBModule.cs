using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.MongoDB;
using Destiny.Core.TaskScheduler.MongoDB.DbContexts;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using System;
using System.IO;

namespace Destiny.Core.TaskScheduler.API.Startups
{
    public class MongoDBModule : MongoDBModuleBase
    {
        protected override void AddDbContext(IServiceCollection services)
        {
            var dbpath = services.GetConfiguration()["SuktCore:DbContext:MongoDBConnectionString"];
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            var dbcontext = Path.Combine(basePath, dbpath);
            if (!File.Exists(dbcontext))
            {
                throw new Exception("未找到存放数据库链接的文件");
            }
            var connection = File.ReadAllText(dbcontext).Trim();
            services.AddMongoDbContext<DefaultMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });
        }
    }
}