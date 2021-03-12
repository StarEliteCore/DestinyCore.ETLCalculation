using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;
using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource
{
    public class DBMetaData : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        public DBMetaData(MetaDataTypeEnum metaDataType, string name, Guid parentId, string describe)
        {
            MetaDataType = metaDataType;
            Name = name;
            Describe = describe;
            this.ParentId = parentId;
        }
        #region Func
        public void Delete()
        {
            this.IsDeleted = true;
        }
        #endregion
        /// <summary>
        /// 元数据类型
        /// </summary>
        [DisplayName("元数据类型")]
        public MetaDataTypeEnum MetaDataType { get; private set; }
        /// <summary>
        /// 元数据名称
        /// </summary>
        [DisplayName("元数据名称")]
        public string Name { get; private set; }
        public DBConnection Connection { get; private set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Describe { get; private set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        [DisplayName("父级ID")]
        public Guid ParentId { get; private set; }
        #region 公共字段
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
        #endregion
    }
}
