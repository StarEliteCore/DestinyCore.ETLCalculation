using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLDataCalculationTransMission.EntityFrameworkCore;
using DestinyCore.ETLDataCalculationTransMission.Shared.Entity;
using DestinyCore.ETLDataCalculationTransMission.Shared.Modules;

namespace DestinyCore.ETLDataCalculationTransMission.Shared
{
    public class EntityFrameworkCoreModule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            AddAddSuktDbContextWnitUnitOfWork(context.Services); ;
            AddRepository(context.Services);

            //return base.ConfigureServices(service);
        }

        protected virtual IServiceCollection AddAddSuktDbContextWnitUnitOfWork(IServiceCollection services)
        {
            services.AddSuktDbContext<DefaultDbContext>();
            services.AddUnitOfWork<DefaultDbContext>();
            return services;
        }

        protected virtual IServiceCollection AddRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IEFCoreRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IAggregateRootRepository<,>), typeof(AggregateRootBaseRepository<,>));
            return services;
        }
    }
}
