using DestinyCore.ETLDispatchCenter.Shared.Extensions;
using Microsoft.Extensions.Logging;
using SqlSugar;
using System;

namespace DestinyCore.ETLDispatchCenter.EntityFrameworkCore.SqlSugar
{
    public class SqlSugarDbContext : ISqlSugarDbContext
    {
        private readonly ILogger _logger;

        public SqlSugarDbContext(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetLogger<ILogger>();
        }

        public SqlSugarClient GetSqlSugarClient(ConnectionConfig connection)
        {
            var db = new SqlSugarClient(connection);
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                _logger.LogInformation($"SqlSugar Executing Sql:{sql}");

            };
            return db;
        }
    }
}
