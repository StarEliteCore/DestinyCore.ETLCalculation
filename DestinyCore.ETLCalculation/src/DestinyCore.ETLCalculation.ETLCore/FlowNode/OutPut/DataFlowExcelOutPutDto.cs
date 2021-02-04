using System.Collections.Generic;
using System.ComponentModel;

namespace DestinyCore.ETLCalculation.ETLCore
{
    /// <summary>
    /// Excel输出组件
    /// </summary>
    [DisplayName("Excel输出组件")]
    public class DataFlowExcelOutPutDto : Node
    {
        /// <summary>
        /// 字段列表
        /// </summary>
        [DisplayName("字段列表")]
        public List<Column> Column { get; set; } = new List<Column>();
        /// <summary>
        /// 输出行
        /// </summary>
        [DisplayName("输出行")]
        public int OutPutRow { get; set; }
        /// <summary>
        /// 首行是否为字段名称
        /// </summary>
        [DisplayName("首行是否为字段名称")]
        public bool FirstLineFieldName { get; set; }
        /// <summary>
        /// Excel输出路径
        /// </summary>
        [DisplayName("Excel输出路径")]
        public string ExcelOutPutPath { get; set; }
    }
    /// <summary>
    /// 输出字段列表
    /// </summary>
    [DisplayName("输出字段列表")]
    public class Column
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        [DisplayName("字段名称")]
        public string TableField { get; set; }
        /// <summary>
        /// Excel列名称
        /// </summary>
        [DisplayName("Excel列名称")]
        public string TableTitle { get; set; }
    }
}
