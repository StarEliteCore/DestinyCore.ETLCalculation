﻿using Destiny.Core.TaskScheduler.Shared.Entity;
using System;
using System.ComponentModel;

namespace Destiny.Core.TaskScheduler.IdentityServerFour
{
    /// <summary>
    /// 用户声明
    /// </summary>
    [DisplayName("用户声明")]
    public abstract class UserClaimBase : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public string Type { get; set; }
    }
}