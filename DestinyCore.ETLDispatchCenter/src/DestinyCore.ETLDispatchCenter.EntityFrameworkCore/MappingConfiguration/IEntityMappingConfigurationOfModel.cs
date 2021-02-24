using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;

namespace DestinyCore.ETLDispatchCenter.Shared
{
    public interface IEntityMappingConfiguration<TEntity, TKey> : IEntityMappingConfiguration where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Map(EntityTypeBuilder<TEntity> builder);
    }
    public interface IAggregateRootMappingConfiguration<TEntity, TKey> : IEntityMappingConfiguration where TEntity : class, IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {
        void Map(EntityTypeBuilder<TEntity> builder);
    }
}
