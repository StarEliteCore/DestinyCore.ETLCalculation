using Microsoft.EntityFrameworkCore;
using DestinyCore.ETLDataCalculationTransMission.Shared.AppOption;
using DestinyCore.ETLDataCalculationTransMission.Shared.DbContextDriven;
using DestinyCore.ETLDataCalculationTransMission.Shared.Entity;

namespace DestinyCore.ETLDataCalculationTransMission.EntityFrameworkCore.DbDrivens
{
    /// <summary>
    /// MySql驱动提供者
    /// </summary>
    public class MySqlDbContextDrivenProvider : IDbContextDrivenProvider
    {
        public DatabaseType DatabaseType => DatabaseType.MySql;
        public DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder, string connectionString, DestinyContextOptionsBuilder optionsBuilder)
        {
            builder.UseMySql(connectionString, opt => opt.MigrationsAssembly(optionsBuilder.MigrationsAssemblyName));
            return builder;
        }
    }
}
