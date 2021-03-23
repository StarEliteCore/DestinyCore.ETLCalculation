using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using System.Collections.Generic;

namespace DestinyCore.ETLDispatchCenter.Dtos
{
    /// <summary>
    /// 通用树形
    /// </summary>
    public class TreeOutPutDto
    {
        /// <summary>
        /// 唯一值
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 是否可选
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public MetaDataTypeEnum MetaDataType { get; set; }
        /// <summary>
        /// 子级
        /// </summary>
        public List<TreeOutPutDto> Children = new List<TreeOutPutDto>();
    }
}
