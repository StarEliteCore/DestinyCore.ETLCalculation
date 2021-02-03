using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.ETLCore.BlockOptions
{
    /// <summary>
    /// Block传输对象基类
    /// </summary>
    public interface IBlockOption
    {
        /// <summary>
        /// 执行节点的Id
        /// </summary>
        Guid NodeId { get; set; }
        /// <summary>
        /// 执行流程的Id
        /// </summary>
        Guid FlowId { get; set; }
        /// <summary>
        /// 数据传输集合
        /// </summary>
        Dictionary<string, object> Data { get; set; }
    }
}
