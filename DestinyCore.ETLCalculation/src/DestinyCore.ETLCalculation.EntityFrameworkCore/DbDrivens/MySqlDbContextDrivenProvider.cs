using Microsoft.EntityFrameworkCore;
using DestinyCore.ETLCalculation.Shared.AppOption;
using DestinyCore.ETLCalculation.Shared.DbContextDriven;
using DestinyCore.ETLCalculation.Shared.Entity;

namespace DestinyCore.ETLCalculation.EntityFrameworkCore.DbDrivens
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
