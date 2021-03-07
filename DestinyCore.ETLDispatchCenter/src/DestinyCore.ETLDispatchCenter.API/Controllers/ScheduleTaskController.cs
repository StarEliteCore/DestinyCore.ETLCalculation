using DestinyCore.ETLDispatchCenter.Application.TaskConfig;
using DestinyCore.ETLDispatchCenter.AspNetCore.ApiBase;
using DestinyCore.ETLDispatchCenter.Dtos.TaskConfig;
using DestinyCore.ETLDispatchCenter.Shared.Audit;
using DestinyCore.ETLDispatchCenter.Shared.OperationResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DestinyCore.ETLDispatchCenter.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Description("任务管理")]
    public class ScheduleTaskController : ApiControllerBase
    {
        private readonly IScheduleTaskContract _scheduleTaskContract;

        public ScheduleTaskController(IScheduleTaskContract scheduleTaskContract)
        {
            _scheduleTaskContract = scheduleTaskContract;
        }
        /// <summary>
        /// 加载任务下拉列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("加载任务下拉列表")]
        public async Task<AjaxResult> GetLoadSelectListItemAsync()
        {
            return (await _scheduleTaskContract.GetLoadSelectListItemAsync()).ToAjaxResult();
        }
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("添加任务")]
        [AuditLog]
        public async Task<AjaxResult> CreateAsync(ScheduleTaskInputDto input)
        {
            return (await _scheduleTaskContract.CreateAsync(input)).ToAjaxResult();
        }
    }
}
