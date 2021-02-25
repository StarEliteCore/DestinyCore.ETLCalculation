using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;
using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.TaskConfig
{
    public class ScheduleTask : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        public ScheduleTask(string taskNumber, string taskName, TaskTypeEnum taskType, string taskConfig, Guid sourceConnectionId, Guid targetConnectionId, string sourceTable, string targetTable)
        {
            TaskName = taskName;
            TaskType = taskType;
            TaskConfig = taskConfig;
            SourceConnectionId = sourceConnectionId;
            TargetConnectionId = targetConnectionId;
            SourceTable = sourceTable;
            TargetTable = targetTable;
            TaskNumber = taskNumber;
        }

        public void Change(string taskNumber, string taskName, TaskTypeEnum taskType, string taskConfig, Guid sourceConnectionId, Guid targetConnectionId, string sourceTable, string targetTable)
        {
            TaskName = taskName;
            TaskType = taskType;
            TaskConfig = taskConfig;
            SourceConnectionId = sourceConnectionId;
            TargetConnectionId = targetConnectionId;
            SourceTable = sourceTable;
            TargetTable = targetTable;
            TaskNumber = taskNumber;
        }
        /// <summary>
        /// 任务编号
        /// </summary>
        [DisplayName("任务编号")]
        public string TaskNumber { get; private set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        [DisplayName("任务名称")]
        public string TaskName { get; private set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        [DisplayName("任务类型")]
        public TaskTypeEnum TaskType { get; private set; }
        /// <summary>
        /// 任务配置信息
        /// </summary>
        [DisplayName("任务配置信息")]
        public string TaskConfig { get; private set; }
        /// <summary>
        /// 源链接
        /// </summary>
        [DisplayName("源链接")]
        public Guid SourceConnectionId { get; private set; }
        /// <summary>
        /// 目标链接
        /// </summary>
        [DisplayName("目标链接")]
        public Guid TargetConnectionId { get; private set; }
        /// <summary>
        /// 源表
        /// </summary>
        [DisplayName("源表")]
        public string SourceTable { get; private set; }
        /// <summary>
        /// 目标表
        /// </summary>
        [DisplayName("目标表")]
        public string TargetTable { get; private set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        [DisplayName("创建人Id")]
        public Guid? CreatedId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public virtual DateTime CreatedAt { get; set; }
        /// <summary>
        /// 修改人ID
        /// </summary>
        [DisplayName("修改人ID")]
        public Guid? LastModifyId { get; set; }
        /// <summary>
        ///修改时间
        /// </summary>
        [DisplayName("修改时间")]
        public virtual DateTime LastModifedAt { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }
    }
}
