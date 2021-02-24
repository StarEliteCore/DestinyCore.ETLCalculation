using System;
using System.Collections.Generic;
using System.Text;

namespace DestinyCore.ETLDispatchCenter.EntityFrameworkCore.MappingConfiguration
{
    public interface IEntityManager
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize();
    }
}
