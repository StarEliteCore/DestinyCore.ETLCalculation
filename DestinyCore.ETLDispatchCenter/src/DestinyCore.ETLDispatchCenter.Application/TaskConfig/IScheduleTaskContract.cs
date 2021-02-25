using DestinyCore.ETLDispatchCenter.Dtos.TaskConfig;
using DestinyCore.ETLDispatchCenter.Shared;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using DestinyCore.ETLDispatchCenter.Shared.Extensions.ResultExtensions;
using DestinyCore.ETLDispatchCenter.Shared.OperationResult;
using System;
using System.Threading.Tasks;

namespace DestinyCore.ETLDispatchCenter.Application.TaskConfig
{
    public interface IScheduleTaskContract : IScopedDependency
    {
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(ScheduleTaskInputDto input);
        /// <summary>
        /// 修改任务配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(ScheduleTaskInputDto input);
        /// <summary>
        /// 表单加载任务配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> GetLoadAsync(Guid id);
        /// <summary>
        /// 分页加载任务配置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IPageResult<ScheduleTaskPageOutPutDto>> GetLoadPageAsync(PageRequest request);
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);
    }
}
