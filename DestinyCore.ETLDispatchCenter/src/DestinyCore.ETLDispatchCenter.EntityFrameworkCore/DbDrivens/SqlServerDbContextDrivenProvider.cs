using Microsoft.EntityFrameworkCore;
using DestinyCore.ETLDispatchCenter.Shared.AppOption;
using DestinyCore.ETLDispatchCenter.Shared.DbContextDriven;
using DestinyCore.ETLDispatchCenter.Shared.Entity;

namespace DestinyCore.ETLDispatchCenter.EntityFrameworkCore.DbDrivens
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
