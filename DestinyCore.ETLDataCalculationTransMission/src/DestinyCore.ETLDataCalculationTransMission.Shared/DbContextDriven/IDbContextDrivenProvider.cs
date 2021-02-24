using Microsoft.EntityFrameworkCore;
using DestinyCore.ETLDataCalculationTransMission.Shared.AppOption;
using DestinyCore.ETLDataCalculationTransMission.Shared.Entity;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.DbContextDriven
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
