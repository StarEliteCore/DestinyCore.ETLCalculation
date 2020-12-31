using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DestinyCore.ETLCalculation.Shared.Entity;
using System;

namespace DestinyCore.ETLCalculation.Shared
{
    public interface IEntityMappingConfiguration<TEntity, TKey> : IEntityMappingConfiguration where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Map(EntityTypeBuilder<TEntity> builder);
    }
}