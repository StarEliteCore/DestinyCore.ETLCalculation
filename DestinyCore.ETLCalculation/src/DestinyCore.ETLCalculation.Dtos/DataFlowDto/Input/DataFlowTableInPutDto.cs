using System.Collections.Generic;
using System.ComponentModel;

namespace IDN.Service.ETLWorkFlow.Node.Dtos.DataFlowDto
{
    /// <summary>
    /// 表输入组件对象
    /// </summary>
    [DisplayName("表输入组件对象")]
    public class DataFlowTableInPutDto : Node
    {
        /// <summary>
        /// 字段列表
        /// </summary>
        [DisplayName("字段列表")]
        public List<string> Column { get; set; }
        /// <summary>
        /// 数据库连接
        /// </summary>
        [DisplayName("数据库连接")]
        public string SQLConntionString { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        [DisplayName("表名称")]
        public string TableName { get; set; }
    }
}
