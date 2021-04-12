using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using DestinyCore.WorkNode.MongoDB.DbContexts;
using DestinyCore.WorkNode.MongoDB.Infrastructure;
using System;

namespace DestinyCore.WorkNode.MongoDB
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbContext<TContext>(this IServiceCollection services, [CanBeNull] Action<MongoDbContextOptions> optionAction) where TContext : MongoDbContextBase
        {
            MongoDbContextOptions options = new MongoDbContextOptions();
            optionAction(options);
            services.AddSingleton<MongoDbContextOptions>(options);
            services.AddScoped<MongoDbContextBase, TContext>();
            return services;
        }
    }
}