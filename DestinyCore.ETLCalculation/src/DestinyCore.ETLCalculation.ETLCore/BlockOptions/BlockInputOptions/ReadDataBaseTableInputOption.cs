using SqlSugar;
using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions
{
    /// <summary>
    /// 读取数据库传入配置项
    /// </summary>
    public class ReadDataBaseTableInputOption : IBlockDataTableInputOption
    {
        /// <summary>
        /// 执行节点的Id
        /// </summary>
        public Guid NodeId { get; set; }
        /// <summary>
        /// 执行流程的Id
        /// </summary>
        public Guid FlowId { get; set; }
        /// <summary>
        /// 查询的字段
        /// </summary>
        public List<string> Column { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public SqlSugarClient sqlSugarClient { get; set; }
        /// <summary>
        /// 数据传输
        /// </summary>
        public Dictionary<string, object> Data { get; set; }
    }
}
