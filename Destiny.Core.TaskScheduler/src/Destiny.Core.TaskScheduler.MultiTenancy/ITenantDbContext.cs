namespace Destiny.Core.TaskScheduler.MultiTenancy
{
    public interface ITenantDbContext
    {
        /// <summary>
        /// 当前租户
        /// </summary>
        TenantInfo TenantInfo { get; }
    }
}