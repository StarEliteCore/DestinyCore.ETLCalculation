using AutoMapper;
using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Shared.Entity;
using System;
using System.ComponentModel;

namespace Destiny.Core.TaskScheduler.Dtos.Identity.Role
{
    [DisplayName("角色分页模型")]
    [AutoMap(typeof(RoleEntity))]
    public class RoleOutPutPageDto : OutputDtoBase<Guid>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称")]
        public string Name { get; set; }

        /// <summary>
        /// 标准化角色名称
        /// </summary>
        [DisplayName("标准化角色名称")]
        public string NormalizedName { get; set; }

        /// <summary>
        /// 租户ID
        /// </summary>
        [DisplayName("租户")]
        public Guid TenantId { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        [DisplayName("是否管理员")]
        public bool IsAdmin { get; set; }
    }
}