using System.ComponentModel;

namespace IDN.Service.ETLWorkFlow.Node.Dtos.DataFlowDto.Enum
{
    /// <summary>
    /// 流程节点类型
    /// </summary>
    [Description("节点类型")]
    public enum NodeTypeEnum
    {
        [Description("表输入")]
        InputTable = 1,
        [Description("Excel输入")]
        InputExcel = 5,
        [Description("表输出")]
        OutputTable = 10,
        [Description("Excel输出")]
        OutputExcel = 15,
    }
}
