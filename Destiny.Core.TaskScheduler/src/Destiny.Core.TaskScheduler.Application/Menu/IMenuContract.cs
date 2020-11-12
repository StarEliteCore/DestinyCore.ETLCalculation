using Destiny.Core.TaskScheduler.Dtos.Menu;
using Destiny.Core.TaskScheduler.Shared;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application
{
    public interface IMenuContract : IScopedDependency
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> InsertAsync(MenuInputDto input);

        /// <summary>
        /// 异步修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(MenuInputDto input);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 获取表格菜单列表
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> GetMenuTableAsync();

        /// <summary>
        /// 加载一个菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> GetLoadFromMenuAsync(Guid id);

        /// <summary>
        /// 根据用户角色获取菜单
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> GetUserMenuTreeAsync();
    }
}