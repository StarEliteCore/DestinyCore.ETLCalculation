using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.ETLCore.DataFlow
{
    public interface IDataFlowData
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
        /// 传输数据
        /// </summary>
        Dictionary<string, object> Data { get; set; }
    }
}
