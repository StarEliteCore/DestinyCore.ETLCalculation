using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.TaskConfig
{
    [Description("任务类型")]
    public enum TaskTypeEnum
    {
        /// <summary>
        /// 数据库导入数据库任务
        /// </summary>
        [Description("数据库导入数据库")]
        DataBaseToDataBase = 0,
        /// <summary>
        /// Http任务
        /// </summary>
        [Description("Http")]
        Http = 5,
        /// <summary>
        /// Excel导入数据库任务
        /// </summary>
        [Description("Excel导入数据库")]
        ExcelToDataBase = 10,
        /// <summary>
        /// 数据库导出Excel任务
        /// </summary>
        [Description("数据库导出Excel")]
        DataBaseToExcel = 15,
    }
}
