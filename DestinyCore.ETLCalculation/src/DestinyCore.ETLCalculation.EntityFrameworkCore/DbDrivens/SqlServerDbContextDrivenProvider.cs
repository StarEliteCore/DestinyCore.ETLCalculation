using Microsoft.EntityFrameworkCore;
using DestinyCore.ETLCalculation.Shared.AppOption;
using DestinyCore.ETLCalculation.Shared.DbContextDriven;
using DestinyCore.ETLCalculation.Shared.Entity;

namespace DestinyCore.ETLCalculation.EntityFrameworkCore.DbDrivens
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
