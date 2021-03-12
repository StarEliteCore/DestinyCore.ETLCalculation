using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Dtos.DataDictionaryDto
{
    /// <summary>
    /// 元数据输入Dto
    /// </summary>
    public class MetaDataInputDto : InputDto<Guid>
    {
        [DisplayName("元数据类型")]
        public MetaDataTypeEnum MetaDataType { get; set; }
        [DisplayName("元数据名称")]
        public string Name { get; set; }
        [DisplayName("备注")]
        public string Describe { get; set; }
    }
    /// <summary>
    /// 元数据输入Dto
    /// </summary>
    public class MetaDataImportInputDto : InputDto<Guid>
    {
        public List<MetaDataInputDto> MetaDatas { get; set; }
    }
}
