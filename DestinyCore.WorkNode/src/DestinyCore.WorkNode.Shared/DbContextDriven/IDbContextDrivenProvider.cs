using Microsoft.EntityFrameworkCore;
using DestinyCore.WorkNode.Shared.AppOption;
using DestinyCore.WorkNode.Shared.Entity;

namespace DestinyCore.WorkNode.Shared.DbContextDriven
{
    public interface IDbContextDrivenProvider : ISingletonDependency
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        DatabaseType DatabaseType { get; }

        /// <summary>
        /// 构建数据库驱动
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>

        DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder, string connectionString, DestinyContextOptionsBuilder optionsBuilder);
    }
}
