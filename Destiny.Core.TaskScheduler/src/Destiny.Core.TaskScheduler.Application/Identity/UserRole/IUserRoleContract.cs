using Destiny.Core.TaskScheduler.Dtos.Identity.UserRole;
using Destiny.Core.TaskScheduler.Shared;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application.Identity.UserRole
{
    public interface IUserRoleContract : IScopedDependency
    {
        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> AllocationRoleAsync(UserRoleInputDto dto);
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> GetLoadUserRoleAsync(Guid id);
    }
}
