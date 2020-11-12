using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.TaskScheduler.Shared.Entity;
using System;

namespace Destiny.Core.TaskScheduler.Shared
{
    public interface IEntityMappingConfiguration<TEntity, TKey> : IEntityMappingConfiguration where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Map(EntityTypeBuilder<TEntity> builder);
    }
}