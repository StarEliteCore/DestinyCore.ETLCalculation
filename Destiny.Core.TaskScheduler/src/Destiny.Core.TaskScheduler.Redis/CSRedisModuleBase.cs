using CSRedis;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Destiny.Core.TaskScheduler.Caching;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using Destiny.Core.TaskScheduler.Shared.Modules;
using System;
using System.IO;

namespace Destiny.Core.TaskScheduler.Redis
{
    public class CSRedisModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var redisPath = service.GetConfiguration()["SuktCore:Redis:ConnectionString"];
            var basePath = ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            var redisConn = Path.Combine(basePath, redisPath);
            if (!File.Exists(redisConn))
            {
                throw new Exception("未找到存放Rdis链接的文件");
            }
            var connStr = File.ReadAllText(redisConn).Trim();
            var csredis = new CSRedisClient(connStr);
            RedisHelper.Initialization(csredis);
            service.TryAddSingleton(typeof(ICache<>), typeof(CSRedisCache<>));
            service.TryAddSingleton(typeof(ICache<,>), typeof(CSRedisCache<,>));
            service.TryAddSingleton<ICache, CSRedisCache>();
        }
    }
}