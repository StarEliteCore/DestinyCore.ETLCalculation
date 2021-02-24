using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DestinyCore.ETLDataCalculationTransMission.MongoDB.Repositorys;
using DestinyCore.ETLDataCalculationTransMission.Shared.Modules;

namespace DestinyCore.ETLDataCalculationTransMission.MongoDB
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