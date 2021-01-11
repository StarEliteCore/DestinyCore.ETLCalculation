using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.Dataflow
{
    public interface IDataFlowBuild<TData>
    {
        /// <summary>
        /// 执行流程的Id
        /// </summary>
        Guid FlowId { get; set; }
        /// <summary>
        /// 传输数据
        /// </summary>
        Dictionary<string, IEnumerable<TData>> CurrentData { get; set; }
    }
}
