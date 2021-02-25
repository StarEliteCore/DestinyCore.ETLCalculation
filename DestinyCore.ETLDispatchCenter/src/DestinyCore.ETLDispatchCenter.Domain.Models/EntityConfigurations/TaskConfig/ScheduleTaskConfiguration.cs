using DestinyCore.ETLDispatchCenter.Domain.Models.TaskConfig;
using DestinyCore.ETLDispatchCenter.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.EntityConfigurations.TaskConfig
{
    public class ScheduleTaskConfiguration : EntityMappingConfiguration<ScheduleTask, Guid>
    {
        public override void Map(EntityTypeBuilder<ScheduleTask> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ETL_ScheduleTask").HasComment("任务管理");
        }
    }
}
