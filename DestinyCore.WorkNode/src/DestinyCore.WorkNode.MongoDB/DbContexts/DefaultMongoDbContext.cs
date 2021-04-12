using DestinyCore.WorkNode.MongoDB.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace DestinyCore.WorkNode.MongoDB.DbContexts
{
    public class DefaultMongoDbContext : MongoDbContextBase
    {
        public DefaultMongoDbContext([NotNull] MongoDbContextOptions options) : base(options)
        {
        }
    }
}