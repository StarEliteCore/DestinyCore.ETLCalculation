using DestinyCore.ETLDispatchCenter.MongoDB.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace DestinyCore.ETLDispatchCenter.MongoDB.DbContexts
{
    public class DefaultMongoDbContext : MongoDbContextBase
    {
        public DefaultMongoDbContext([NotNull] MongoDbContextOptions options) : base(options)
        {
        }
    }
}