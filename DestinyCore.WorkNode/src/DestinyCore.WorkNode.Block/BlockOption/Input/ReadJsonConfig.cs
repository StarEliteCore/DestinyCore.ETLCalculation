using DestinyCore.WorkNode.BlockOption.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DestinyCore.WorkNode.BlockOption.Input
{
    /// <summary>
    /// 下载Json文件，并读取到数据流中配置
    /// </summary>
    public class ReadJsonConfig
    {
        /// <summary>
        /// FTP配置项
        /// </summary>
        public FtpConfigInput FtpConfig { get; set; }
        /// <summary>
        /// Json读取配置
        /// </summary>
        public List<JsonReadConfigInput> JsonReadConfig { get; set; }
    }
    /// <summary>
    /// FTP配置项
    /// </summary>
    public class FtpConfigInput
    {
        /// <summary>
        /// FTP主机地址
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 服务器密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// FTP文件路径
        /// </summary>
        public string TargetfilePath { get; set; }
        /// <summary>
        /// FTP端口
        /// </summary>
        public int Prot { get; set; }
        /// <summary>
        /// 是否忽略空文件
        /// </summary>
        public bool isIgnoreEmptyfile { get; set; }

    }
    /// <summary>
    /// Json读取配置
    /// </summary>
    public class JsonReadConfigInput
    {
        /// <summary>
        /// 唯一键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Json字段路径
        /// </summary>
        public string PathField { get; set; }
        /// <summary>
        /// 数据流内字段名称
        /// </summary>
        public string FLowField { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public FieldTypeEnum FieldType { get; set; }
    }
}
