using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.TaskScheduler.Shared;
using System;

namespace Destiny.Core.TaskScheduler.Domain.Models
{
    public class UserRoleConfiguration : EntityMappingConfiguration<UserRoleEntity, Guid>
    {
        public override void Map(EntityTypeBuilder<UserRoleEntity> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.IsDeleted).HasDefaultValue(false);
            b.ToTable("UserRole");
        }
    }
}