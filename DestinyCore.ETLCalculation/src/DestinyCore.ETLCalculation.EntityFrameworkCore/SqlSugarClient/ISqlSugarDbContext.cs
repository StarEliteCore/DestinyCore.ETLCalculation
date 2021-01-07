using IDN.Service.ETLWorkFlow.Node.Shared;
using SqlSugar;

namespace IDN.Service.ETLWorkFlow.Node.EntityFrameworkCore.SqlSugar
{
    public interface ISqlSugarDbContext : IScopedDependency
    {
        SqlSugarClient GetSqlSugarClient(ConnectionConfig connection);
    }
}
