using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.TaskScheduler.Domain.Models.Authority;
using Destiny.Core.TaskScheduler.Shared;
using System;

namespace Destiny.Core.TaskScheduler.Domain.Models.EntityConfigurations.Authority
{
    public class RoleMenuConfiguration : EntityMappingConfiguration<RoleMenuEntity, Guid>
    {
        public override void Map(EntityTypeBuilder<RoleMenuEntity> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("RoleMenu");
        }
    }
}