using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.DBConn
{
    /// <summary>
    /// 数据库连接类型
    /// </summary>
    public enum DBTypeEnum
    {
        [Description("MySql")]
        MySql = 0,
        [Description("MySql")]
        SqlServer = 5,
        [Description("Oracle")]
        Oracle = 10,
    }
}
