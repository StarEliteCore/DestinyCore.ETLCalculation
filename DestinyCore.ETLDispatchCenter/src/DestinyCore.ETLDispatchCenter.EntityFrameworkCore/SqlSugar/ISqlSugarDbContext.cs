using DestinyCore.ETLDispatchCenter.Shared;
using SqlSugar;

namespace DestinyCore.ETLDispatchCenter.EntityFrameworkCore.SqlSugar
{
    public interface ISqlSugarDbContext : IScopedDependency
    {
        SqlSugarClient GetSqlSugarClient(ConnectionConfig connection);
    }
}
