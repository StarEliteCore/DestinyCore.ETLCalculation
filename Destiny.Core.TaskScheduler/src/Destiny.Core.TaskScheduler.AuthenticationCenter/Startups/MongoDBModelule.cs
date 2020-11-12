using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.MongoDB;
using Destiny.Core.TaskScheduler.MongoDB.DbContexts;
using Destiny.Core.TaskScheduler.Shared.Extensions;

namespace Destiny.Core.TaskScheduler.AuthenticationCenter.Startups
{
    public class MongoDBModelule : MongoDBModuleBase
    {
        protected override void AddDbContext(IServiceCollection services)
        {
            var connection = services.GetConfiguration()["SuktCore:DbContext:MongoDBConnectionString"];
            services.AddMongoDbContext<DefaultMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });
        }
    }
}
