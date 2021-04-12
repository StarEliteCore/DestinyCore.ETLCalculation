using Microsoft.EntityFrameworkCore;
using DestinyCore.WorkNode.Shared.AppOption;
using DestinyCore.WorkNode.Shared.DbContextDriven;
using DestinyCore.WorkNode.Shared.Entity;

namespace DestinyCore.WorkNode.EntityFrameworkCore.DbDrivens
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
