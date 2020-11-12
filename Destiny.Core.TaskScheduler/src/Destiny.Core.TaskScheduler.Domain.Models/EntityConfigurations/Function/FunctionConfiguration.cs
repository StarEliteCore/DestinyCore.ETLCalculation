﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.TaskScheduler.Domain.Models.Function;
using Destiny.Core.TaskScheduler.Shared;
using System;

namespace Destiny.Core.TaskScheduler.Domain.Models.EntityConfigurations.Function
{
    /// <summary>
    /// 功能模块数据库映射配置
    /// </summary>
    public class FunctionConfiguration : EntityMappingConfiguration<FunctionEntity, Guid>
    {
        public override void Map(EntityTypeBuilder<FunctionEntity> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Name).HasMaxLength(100).IsRequired();
            b.Property(o => o.Description).HasMaxLength(200).IsRequired();
            b.Property(o => o.LinkUrl).HasMaxLength(300).IsRequired();
            b.Property(o => o.IsEnabled).HasDefaultValue(false);
            b.ToTable("Function");
        }
    }
}