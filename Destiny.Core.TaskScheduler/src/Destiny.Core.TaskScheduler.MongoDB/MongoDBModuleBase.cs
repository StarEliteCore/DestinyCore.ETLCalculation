using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Destiny.Core.TaskScheduler.MongoDB.Repositorys;
using Destiny.Core.TaskScheduler.Shared.Modules;

namespace Destiny.Core.TaskScheduler.MongoDB
{
    public abstract class MongoDBModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            AddDbContext(context.Services);
            AddRepository(context.Services);
        }

        public virtual void AddRepository(IServiceCollection services)
        {
            services.TryAddScoped(typeof(IMongoDBRepository<,>), typeof(MongoDBRepository<,>));
        }

        protected abstract void AddDbContext(IServiceCollection services);
    }
}