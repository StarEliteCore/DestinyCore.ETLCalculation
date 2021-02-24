using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using DestinyCore.ETLDispatchCenter.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.EntityConfigurations.DBConnResource
{
    public class DBConnectionConfiguration : EntityMappingConfiguration<DBConnection, Guid>
    {
        public override void Map(EntityTypeBuilder<DBConnection> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ETL_DBConnection").HasComment("数据库连接管理");
        }
    }
}
