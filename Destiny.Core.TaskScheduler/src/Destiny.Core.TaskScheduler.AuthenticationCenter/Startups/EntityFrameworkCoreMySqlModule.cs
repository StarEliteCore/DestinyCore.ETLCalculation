using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.MultiTenancy;
using Destiny.Core.TaskScheduler.Shared;
using Destiny.Core.TaskScheduler.Shared.Entity;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using System;
using System.IO;
using System.Reflection;

namespace Destiny.Core.TaskScheduler.AuthenticationCenter.Startups
{
    public class EntityFrameworkCoreMySqlModule : EntityFrameworkCoreModuleBase
    {
        /// <summary>
        /// 添加仓储
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        protected override IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IEFCoreRepository<,>), typeof(BaseRepository<,>));
            return services;
        }

        /// <summary>
        /// 添加工作单元
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        protected override IServiceCollection AddUnitOfWork(IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork<DefaultDbContext>>();
        }

        /// <summary>
        /// 重写方法
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        protected override IServiceCollection UseSql(IServiceCollection services)
        {
            var Dbpath = services.GetConfiguration()["SuktCore:DbContext:MysqlConnectionString"];
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            var dbcontext = Path.Combine(basePath, Dbpath);
            var Assembly = typeof(EntityFrameworkCoreMySqlModule).GetTypeInfo().Assembly.GetName().Name;//获取程序集
            if (!File.Exists(dbcontext))
            {
                throw new Exception("未找到存放数据库链接的文件");
            }
            var mysqlconn = File.ReadAllText(dbcontext).Trim(); ;
            services.AddDbContext<DefaultDbContext>((serviceProvider, options) =>
            {
                var resolver = serviceProvider.GetRequiredService<ISuktConnectionStringResolver>();
                //var ss = resolver.Resolve();
                options.UseMySql(mysqlconn, assembly => { assembly.MigrationsAssembly("Destiny.Core.TaskScheduler.Domain.Models"); });
            });
            return services;
        }
    }
}