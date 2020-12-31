using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLCalculation.EntityFrameworkCore;
using DestinyCore.ETLCalculation.Shared.Entity;
using DestinyCore.ETLCalculation.Shared.Modules;

namespace DestinyCore.ETLCalculation.Shared
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
            return services;
        }
    }
}
