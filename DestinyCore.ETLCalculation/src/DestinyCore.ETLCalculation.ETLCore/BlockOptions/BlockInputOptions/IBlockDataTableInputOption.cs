using SqlSugar;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions
{
    public interface IBlockDataTableInputOption : IBlockOption
    {
        /// <summary>
        /// 数据库链接对象
        /// </summary>
        SqlSugarClient sqlSugarClient { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        string TableName { get; set; }
        /// <summary>
        /// 查询的字段
        /// </summary>
        List<string> Column { get; set; }
    }
}
