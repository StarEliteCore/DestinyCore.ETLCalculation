using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using DestinyCore.ETLDispatchCenter.Shared;
using DestinyCore.ETLDispatchCenter.Shared.OperationResult;
using System;
using System.Threading.Tasks;

namespace DestinyCore.ETLDispatchCenter.Domain.Services.DBConnResourceDomainService
{
    public interface IDBConnectionDomainService : IScopedDependency
    {
        /// <summary>
        /// 添加数据库连接资源
        /// </summary>
        /// <param name="apiResource"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateDBConnectionAsync(DBConnection dBConnection);
        /// <summary>
        /// 修改数据库连接资源
        /// </summary>
        /// <param name="dBConnection"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateDBConnectionAsync(DBConnection dBConnection);
        /// <summary>
        /// 获取一个链接
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DBConnection> GetById(Guid id);
    }
}
