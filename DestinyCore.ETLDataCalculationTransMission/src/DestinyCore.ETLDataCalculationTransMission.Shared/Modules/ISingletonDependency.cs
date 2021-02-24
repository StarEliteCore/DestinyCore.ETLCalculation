using DestinyCore.ETLDataCalculationTransMission.Shared.Attributes.Dependency;

namespace DestinyCore.ETLDataCalculationTransMission.Shared
{
    /// <summary>
    /// 实现此接口的类型将自动注册为<see cref="ServiceLifetime.Singleton"/>模式
    /// </summary>
    [IgnoreDependency]
    public interface ISingletonDependency
    {
    }
}