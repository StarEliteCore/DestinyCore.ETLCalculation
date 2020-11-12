using Destiny.Core.TaskScheduler.Shared.Enums;

namespace Destiny.Core.TaskScheduler.Shared.Filter
{
    /// <summary>
    ///
    /// </summary>
    public class FilterCondition
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 过滤操作器
        /// </summary>
        public FilterOperator Operator { get; set; } = FilterOperator.Equal;
    }
}