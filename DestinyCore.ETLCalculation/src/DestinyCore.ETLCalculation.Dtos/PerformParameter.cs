using System;

namespace DestinyCore.ETLCalculation.Dtos
{
    public class PerformParameter
    {
        /// <summary>
        /// 要执行的命令程序
        /// </summary>
        public string FileName { get; set; }
        ///// <summary>
        ///// 执行命令程序参数
        ///// </summary>
        public string Arguments { get; set; }
        /// <summary>
        /// 任务实例Id
        /// </summary>
        public Guid TaskInstanceId { get; set; }
        /// <summary>
        /// 进程ID
        /// </summary>
        public int ProcessId { get; set; }
    }
}
