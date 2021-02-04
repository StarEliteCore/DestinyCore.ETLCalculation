using System.ComponentModel;

namespace DestinyCore.ETLCalculation.ETLCore
{
    /// <summary>
    /// 流程节点类型
    /// </summary>
    [Description("节点类型")]
    public enum NodeTypeEnum
    {
        /// <summary>
        /// 表输入
        /// </summary>
        [Description("表输入")]
        InputTable = 1,
        /// <summary>
        /// Excel输入
        /// </summary>
        [Description("Excel输入")]
        InputExcel = 5,
        /// <summary>
        /// 表输出
        /// </summary>
        [Description("表输出")]
        OutputTable = 10,
        /// <summary>
        /// Excel输出
        /// </summary>
        [Description("Excel输出")]
        OutputExcel = 15,
    }
}
