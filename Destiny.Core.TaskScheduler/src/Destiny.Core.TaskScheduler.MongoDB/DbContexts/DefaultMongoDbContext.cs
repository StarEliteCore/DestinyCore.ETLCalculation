using Destiny.Core.TaskScheduler.MongoDB.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Destiny.Core.TaskScheduler.MongoDB.DbContexts
{
    public class DefaultMongoDbContext : MongoDbContextBase
    {
        public DefaultMongoDbContext([NotNull] MongoDbContextOptions options) : base(options)
        {
        }
    }
}