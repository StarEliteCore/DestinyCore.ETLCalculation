using System.ComponentModel;

namespace IDN.Service.ETLWorkFlow.Node.Dtos.DataFlowDto.Enum
{
    /// <summary>
    /// 表输出更新方式
    /// </summary>
    [Description("表输出更新方式")]
    public enum TableUpdateMethod
    {
        /// <summary>
        /// 数据覆盖
        /// </summary>
        [Description("数据覆盖")]
        DataCoverage = 1,
        /// <summary>
        /// 数据更新
        /// </summary>
        [Description("数据更新")]
        DataUpdate = 5,
        /// <summary>
        /// 更新插入
        /// </summary>
        [Description("更新插入")]
        UpdateInsert = 10,
    }
}
