﻿using System.Threading.Tasks;

namespace DestinyCore.WorkNode.Shared.Permission
{
    public interface IAuthorityVerification : IScopedDependency
    {
        /// <summary>
        /// 判断用户是否有权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> IsPermission(string url);
    }
}