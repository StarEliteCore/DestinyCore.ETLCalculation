﻿using DestinyCore.ETLDispatchCenter.Domain.Models.DBConn;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;
using System.ComponentModel;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource
{
    /// <summary>
    /// 数据库资源连接
    /// </summary>
    [DisplayName("数据库资源连接")]
    public class DBConnection : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {
        public DBConnection(string connectionName, string memo, string host, int prot, string userName, string passWord, DBTypeEnum dBType, int maxConnSize)
        {
            ConnectionName = connectionName;
            Memo = memo;
            Host = host;
            Prot = prot;
            UserName = userName;
            PassWord = passWord;
            DBType = dBType;
            MaxConnSize = maxConnSize;
        }
        #region Func
        /// <summary>
        /// 修改数据连接字段
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="memo"></param>
        /// <param name="host"></param>
        /// <param name="prot"></param>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="dBType"></param>
        /// <param name="maxConnSize"></param>
        public void Update(string connectionName, string memo, string host, int prot, string userName, string passWord, DBTypeEnum dBType, int maxConnSize)
        {
            ConnectionName = connectionName;
            Memo = memo;
            Host = host;
            Prot = prot;
            UserName = userName;
            PassWord = passWord;
            DBType = dBType;
            MaxConnSize = maxConnSize;
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            IsDeleted = true;
        }
        #endregion

        /// <summary>
        /// 连接名称
        /// </summary>
        [DisplayName("连接名称")]
        public string ConnectionName { get; private set; }
        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Memo { get; private set; }
        /// <summary>
        /// 主机
        /// </summary>
        [DisplayName("主机")]
        public string Host { get; private set; }
        /// <summary>
        /// 端口
        /// </summary>
        [DisplayName("端口")]
        public int Prot { get; private set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        public string UserName { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        public string PassWord { get; private set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        [DisplayName("数据库类型")]
        public DBTypeEnum DBType { get; private set; }
        /// <summary>
        /// 最大连接数
        /// </summary>
        [DisplayName("最大连接数")]
        public int MaxConnSize { get; private set; }
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
