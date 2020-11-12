using Microsoft.AspNetCore.Mvc;
using Destiny.Core.TaskScheduler.Application.MenuFunction;
using Destiny.Core.TaskScheduler.AspNetCore.ApiBase;
using Destiny.Core.TaskScheduler.Dtos.MenuFunction;
using Destiny.Core.TaskScheduler.Shared.Audit;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.API.Controllers
{
    [Description("菜单功能管理")]
    public class MenuFunctionController : ApiControllerBase
    {
        private readonly IMenuFunctionContract _menuFunctionContract;

        public MenuFunctionController(IMenuFunctionContract menuFunctionContract)
        {
            _menuFunctionContract = menuFunctionContract;
        }
        /// <summary>
        /// 分配菜单功能
        /// </summary>
        /// <returns></returns>
        [Description("分配菜单功能")]
        [HttpPost]
        [AuditLog]
        public async Task<AjaxResult> AllocationMenuFunctionAsync(MenuFunctionInputDto input)
        {
            return (await _menuFunctionContract.AllocationMenuFunctionAsync(input)).ToAjaxResult();
        }
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <returns></returns>
        [Description("获取菜单功能")]
        [HttpGet]
        public async Task<AjaxResult> GetLoadMenuFunctionAsync(Guid? id)
        {
            return (await _menuFunctionContract.GetLoadMenuFunctionAsync(id.Value)).ToAjaxResult();
        }
    }
}
