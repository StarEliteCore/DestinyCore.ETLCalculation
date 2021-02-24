using System;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Attributes
{
    /// <summary>
    /// 禁用审计
    /// </summary
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class DisableAuditingAttribute : Attribute
    {

    }
}
