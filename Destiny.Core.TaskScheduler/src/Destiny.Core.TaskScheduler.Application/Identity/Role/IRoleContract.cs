using Destiny.Core.TaskScheduler.Dtos.Identity.Role;
using Destiny.Core.TaskScheduler.Shared;
using Destiny.Core.TaskScheduler.Shared.Entity;
using Destiny.Core.TaskScheduler.Shared.Extensions.ResultExtensions;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application.Identity.Role
{
    public interface IRoleContract : IScopedDependency
    {
        /// <summary>
        /// 创建角色及分配权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(RoleInputDto input);

        /// <summary>
        /// 修改角色及分配权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(RoleInputDto input);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 分页获取角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPageResult<RoleOutPutPageDto>> GetPageAsync(PageRequest request);
        /// <summary>
        /// 角色分配权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> AllocationRoleMenuAsync(RoleMenuInputDto dto);
    }
}
