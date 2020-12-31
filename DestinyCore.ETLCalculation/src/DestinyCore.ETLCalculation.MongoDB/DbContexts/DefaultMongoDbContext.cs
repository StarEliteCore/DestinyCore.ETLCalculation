using DestinyCore.ETLCalculation.MongoDB.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace DestinyCore.ETLCalculation.MongoDB.DbContexts
{
    public class DefaultMongoDbContext : MongoDbContextBase
    {
        public DefaultMongoDbContext([NotNull] MongoDbContextOptions options) : base(options)
        {
        }
    }
}