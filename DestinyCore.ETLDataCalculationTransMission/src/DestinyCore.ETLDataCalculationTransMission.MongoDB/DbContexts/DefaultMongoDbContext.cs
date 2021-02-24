using DestinyCore.ETLDataCalculationTransMission.MongoDB.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace DestinyCore.ETLDataCalculationTransMission.MongoDB.DbContexts
{
    public class DefaultMongoDbContext : MongoDbContextBase
    {
        public DefaultMongoDbContext([NotNull] MongoDbContextOptions options) : base(options)
        {
        }
    }
}