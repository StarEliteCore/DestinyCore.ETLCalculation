using DestinyCore.ETLDispatchCenter.Domain.Models.TaskConfig;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;
using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Dtos.TaskConfig
{
    /// <summary>
    /// 任务配置
    /// </summary>
    public class ScheduleTaskInputDto : InputDto<Guid>
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
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Describe { get; set; }
    }
}
