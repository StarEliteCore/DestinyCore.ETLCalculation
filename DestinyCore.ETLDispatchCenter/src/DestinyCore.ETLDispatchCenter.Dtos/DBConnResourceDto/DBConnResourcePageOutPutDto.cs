using AutoMapper;
using DestinyCore.ETLDispatchCenter.Domain.Models.DBConn;
using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;
using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Dtos.DBConnResourceDto
{
    [AutoMap(typeof(DBConnection))]
    public class DBConnResourcePageOutPutDto : OutputDtoBase<Guid>
    {
        /// <summary>
        /// 连接名称
        /// </summary>
        [DisplayName("连接名称")]
        public string ConnectionName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Memo { get; set; }
        /// <summary>
        /// 主机
        /// </summary>
        [DisplayName("主机")]
        public string Host { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        [DisplayName("端口")]
        public int Port { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        public string PassWord { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        [DisplayName("数据库类型")]
        public DBTypeEnum DBType { get; set; }
    }
}
