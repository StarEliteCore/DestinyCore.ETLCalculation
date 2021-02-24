using CSRedis;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DestinyCore.ETLDataCalculationTransMission.Caching;
using DestinyCore.ETLDataCalculationTransMission.Shared.Extensions;
using DestinyCore.ETLDataCalculationTransMission.Shared.Modules;

namespace DestinyCore.ETLDataCalculationTransMission.Redis
{
    public class CSRedisModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            //var redisPath = service.GetConfiguration()["SuktCore:Redis:ConnectionString"];
            //var basePath = ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            //var redisConn = Path.Combine(basePath, redisPath);
            //if (!File.Exists(redisConn))
            //{
            //    throw new Exception("未找到存放Rdis链接的文件");
            //}
            var connStr = service.GetFileByConfiguration("SuktCore:Redis:ConnectionString", "未找到存放Rdis链接的文件"); //File.ReadAllText(redisConn).Trim();
            var csredis = new CSRedisClient(connStr);
            RedisHelper.Initialization(csredis);
            service.TryAddSingleton(typeof(ICache<>), typeof(CSRedisCache<>));
            service.TryAddSingleton(typeof(ICache<,>), typeof(CSRedisCache<,>));
            service.TryAddSingleton<ICache, CSRedisCache>();
        }
    }
}
