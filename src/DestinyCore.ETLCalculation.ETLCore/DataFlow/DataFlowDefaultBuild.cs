using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.ETLCore.DataFlow
{
    /// <summary>
    /// 默认数据传输对象
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class DataFlowDefaultBuild : IDataFlowData
    {
        public DataFlowDefaultBuild()
        {
            Data = new Dictionary<string, object>();
        }
        /// <summary>
        /// 执行节点的Id
        /// </summary>
        public Guid NodeId { get; set; }
        /// <summary>
        /// 执行流程的Id
        /// </summary>
        public Guid FlowId { get; set; }
        /// <summary>
        /// DataFlow数据流程内的数据流转
        /// </summary>
        public Dictionary<string, object> Data { get; set; }
    }
}
