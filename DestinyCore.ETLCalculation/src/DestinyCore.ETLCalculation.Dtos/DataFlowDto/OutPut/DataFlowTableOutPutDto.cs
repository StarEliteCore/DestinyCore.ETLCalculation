using System.Collections.Generic;
using System.ComponentModel;

namespace IDN.Service.ETLWorkFlow.Node.Dtos.DataFlowDto
{
    /// <summary>
    /// 表输出组件对象
    /// </summary>
    [DisplayName("表输出组件对象")]
    public class DataFlowTableOutPutDto : INodeDto
    {
        /// <summary>
        /// 字段列表
        /// </summary>
        [DisplayName("字段列表")]
        public List<CloumnMapp> CloumnMapping { get; set; }
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
        /// <summary>
        /// 更新方式
        /// </summary>
        [DisplayName("更新方式")]
        public TableUpdate TableUpdate { get; set; }

    }
    /// <summary>
    /// 更新方式
    /// </summary>
    [DisplayName("更新方式")]
    public class TableUpdate
    {
        /// <summary>
        /// 数据更新方式
        /// </summary>
        [DisplayName("数据更新方式")]
        public TableUpdateMethod TableUpdateMethod { get; set; }
        /// <summary>
        /// 批量行更新数
        /// </summary>
        [DisplayName("批量行更新数")]
        public int Row { get; set; }
        /// <summary>
        /// 是否截断表
        /// </summary>
        [DisplayName("是否截断表")]
        public bool IsTruncate { get; set; }
    }
    /// <summary>
    /// 表输出映射关系对象
    /// </summary>
    [DisplayName("表输出映射关系对象")]
    public class CloumnMapp
    {
        /// <summary>
        /// 来源字段
        /// </summary>
        [DisplayName("来源")]
        public string SourceName { get; set; }
        /// <summary>
        /// 目标字段
        /// </summary>
        [DisplayName("目标字段")]
        public string TargetName { get; set; }
    }
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
