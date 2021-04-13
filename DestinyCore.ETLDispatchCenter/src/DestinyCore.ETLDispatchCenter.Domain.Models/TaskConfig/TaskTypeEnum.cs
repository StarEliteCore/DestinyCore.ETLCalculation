using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.TaskConfig
{
    [Description("任务类型")]
    public enum TaskTypeEnum
    {
        /// <summary>
        /// 数据库导入数据库任务
        /// </summary>
        [Description("数据库")]
        DataBase = 0,
        /// <summary>
        /// Http任务
        /// </summary>
        [Description("FtpJson")]
        FtpJson = 5,
        /// <summary>
        /// Excel导入数据库任务
        /// </summary>
        [Description("Excel")]
        Excel = 10,
    }
}
