using DestinyCore.ETLDispatchCenter.Domain.Models.TaskConfig;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;
using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Dtos.TaskConfig
{
    public class ScheduleTaskPageOutPutDto : OutputDtoBase<Guid>
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        [DisplayName("任务编号")]
        public string TaskNumber { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        [DisplayName("任务名称")]
        public string TaskName { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        [DisplayName("任务类型")]
        public TaskTypeEnum TaskType { get; set; }
        /// <summary>
        /// 任务配置信息
        /// </summary>
        [DisplayName("任务配置信息")]
        public string TaskConfig { get; set; }
        /// <summary>
        /// 源链接
        /// </summary>
        [DisplayName("源链接")]
        public Guid SourceConnectionId { get; set; }
        /// <summary>
        /// 目标链接
        /// </summary>
        [DisplayName("目标链接")]
        public Guid TargetConnectionId { get; set; }
        /// <summary>
        /// 源表
        /// </summary>
        [DisplayName("源表")]
        public string SourceTable { get; set; }
        /// <summary>
        /// 目标表
        /// </summary>
        [DisplayName("目标表")]
        public string TargetTable { get; set; }
    }
}
