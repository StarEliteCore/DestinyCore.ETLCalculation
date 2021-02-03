using DestinyCore.ETLCalculation.Shared;
using SqlSugar;

namespace DestinyCore.ETLCalculation.EntityFrameworkCore
{
    public interface ISqlSugarDbContext : IScopedDependency
    {
        SqlSugarClient GetSqlSugarClient(ConnectionConfig connection);
    }
}
