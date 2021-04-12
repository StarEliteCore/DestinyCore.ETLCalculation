using Microsoft.EntityFrameworkCore;
using DestinyCore.WorkNode.Shared.AppOption;
using DestinyCore.WorkNode.Shared.DbContextDriven;
using DestinyCore.WorkNode.Shared.Entity;
using System;

namespace DestinyCore.WorkNode.EntityFrameworkCore.DbDrivens
{
    /// <summary>
    /// MySql驱动提供者
    /// </summary>
    public class MySqlDbContextDrivenProvider : IDbContextDrivenProvider
    {
        public DatabaseType DatabaseType => DatabaseType.MySql;
        public DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder, string connectionString, DestinyContextOptionsBuilder optionsBuilder)
        {
            builder.UseMySql(connectionString,new MySqlServerVersion(new Version(8, 0, 21)), opt => opt.MigrationsAssembly(optionsBuilder.MigrationsAssemblyName));
            return builder;
        }
    }
}
