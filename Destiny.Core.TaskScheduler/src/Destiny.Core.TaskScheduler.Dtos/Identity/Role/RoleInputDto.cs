using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Shared.Attributes.AutoMapper;
using Destiny.Core.TaskScheduler.Shared.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.TaskScheduler.Dtos.Identity.Role
{
    [DisplayName("角色管理新增/修改Dto")]
    [SuktAutoMapper(typeof(RoleEntity))]
    public class RoleInputDto : InputDto<Guid>
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
        /// 是否管理员
        /// </summary>
        [DisplayName("是否管理员")]
        public bool IsAdmin { get; set; }
    }
    /// <summary>
    /// 角色设置权限Dto
    /// </summary>
    public class RoleMenuInputDto : InputDto<Guid>
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        [DisplayName("菜单Id")]
        public List<Guid> MenuIds { get; set; }
    }

}
