using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using DestinyCore.ETLDispatchCenter.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.EntityConfigurations.DBConnResource
{
    public class DBMetaDataConfiguration : EntityMappingConfiguration<DBMetaData, Guid>
    {
        public override void Map(EntityTypeBuilder<DBMetaData> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ETL_DBMetaData").HasComment("元数据管理");
        }
    }
}
