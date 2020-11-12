﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Destiny.Core.TaskScheduler.Application.LoginIdentity;
using Destiny.Core.TaskScheduler.AspNetCore.ApiBase;
using Destiny.Core.TaskScheduler.Dtos.LoginIdentity;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.API.Controllers
{
    /// <summary>
    /// 身份认证管理
    /// </summary>
    [ApiController]
    [Description("身份认证管理")]
    public class IdentityController : ApiControllerBase
    {
        private readonly IIdentityContract _identityContract;

        public IdentityController(IIdentityContract identityContract)
        {
            _identityContract = identityContract;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("登录")]
        [AllowAnonymous]
        public async Task<AjaxResult> LoginAsync([FromBody] LoginInputDto loginDto)
        {
            var result = await _identityContract.Login(loginDto);
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);//用户标识
            identity.AddClaims(result.cliams);
            return result.item.ToAjaxResult();
        }
    }
}