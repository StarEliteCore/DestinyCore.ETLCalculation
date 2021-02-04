using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions
{
    public interface IBlockDataTableInputOption : IBlockOption
    {
        /// <summary>
        /// 表名称
        /// </summary>
        string TableName { get; set; }
        /// <summary>
        /// 查询的字段
        /// </summary>
        List<string> Column { get; set; }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnectionString { get; set; }

    }
}
