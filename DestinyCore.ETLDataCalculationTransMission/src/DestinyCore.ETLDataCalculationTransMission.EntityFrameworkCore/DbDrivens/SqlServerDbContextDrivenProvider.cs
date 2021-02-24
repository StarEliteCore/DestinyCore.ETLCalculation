using Microsoft.EntityFrameworkCore;
using DestinyCore.ETLDataCalculationTransMission.Shared.AppOption;
using DestinyCore.ETLDataCalculationTransMission.Shared.DbContextDriven;
using DestinyCore.ETLDataCalculationTransMission.Shared.Entity;

namespace DestinyCore.ETLDataCalculationTransMission.EntityFrameworkCore.DbDrivens
{
    /// <summary>
    /// SqlServer驱动提供者
    /// </summary>
    public class SqlServerDbContextDrivenProvider : IDbContextDrivenProvider
    {
        public DatabaseType DatabaseType => DatabaseType.SqlServer;

        public DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder, string connectionString, DestinyContextOptionsBuilder optionsBuilder)
        {
            builder.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(optionsBuilder.MigrationsAssemblyName));
            return builder;
        }
    }
}
