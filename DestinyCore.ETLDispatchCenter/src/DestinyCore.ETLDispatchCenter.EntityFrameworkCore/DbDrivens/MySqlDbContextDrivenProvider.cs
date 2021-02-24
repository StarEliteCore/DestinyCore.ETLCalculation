using Microsoft.EntityFrameworkCore;
using DestinyCore.ETLDispatchCenter.Shared.AppOption;
using DestinyCore.ETLDispatchCenter.Shared.DbContextDriven;
using DestinyCore.ETLDispatchCenter.Shared.Entity;

namespace DestinyCore.ETLDispatchCenter.EntityFrameworkCore.DbDrivens
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
