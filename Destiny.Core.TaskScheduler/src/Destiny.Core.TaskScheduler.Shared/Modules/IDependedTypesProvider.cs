using System;

namespace Destiny.Core.TaskScheduler.Shared.Modules
{
    public interface IDependedTypesProvider
    {
        /// <summary>
        /// 得到依赖类型集合
        /// </summary>
        /// <returns></returns>
        Type[] GetDependedTypes();
    }
}