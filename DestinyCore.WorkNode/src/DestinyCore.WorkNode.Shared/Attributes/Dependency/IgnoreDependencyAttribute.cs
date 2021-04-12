using System;

namespace DestinyCore.WorkNode.Shared.Attributes.Dependency
{
    /// <summary>
    /// 配置此特性将忽略依赖注入自动映射
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class IgnoreDependencyAttribute : Attribute
    {
    }
}