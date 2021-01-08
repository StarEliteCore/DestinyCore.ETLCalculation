using IDN.Service.ETLWorkFlow.Node.Dtos.DataFlowDto.Enum;
using System.ComponentModel;

namespace IDN.Service.ETLWorkFlow.Node.Dtos.DataFlowDto
{
    [DisplayName("节点运转Dto")]
    public class DataFlowNodeDto
    {
        /// <summary>
        /// 节点类型
        /// </summary>
        [DisplayName("节点类型")]
        public NodeTypeEnum NodeType { get; set; }
        /// <summary>
        /// Node对象字符串
        /// </summary>
        [DisplayName("Node对象字符串")]
        public string NodeJson { get; set; }
        /// <summary>
        /// 运行顺序
        /// </summary>
        [DisplayName("运行顺序")]
        public int Sort { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        public string Title { get; set; }
        /// <summary>
        /// 组件类型
        /// </summary>
        [DisplayName("组件类型")]
        public string AssemblyType { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Describe { get; set; }


    }
}
