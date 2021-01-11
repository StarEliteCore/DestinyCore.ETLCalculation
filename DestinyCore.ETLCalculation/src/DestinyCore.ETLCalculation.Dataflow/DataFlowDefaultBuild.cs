using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.Dataflow
{
    /// <summary>
    /// 默认传输对象
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class DataFlowDefaultBuild<TData> : IDataFlowBuild<TData>
    {
        public Guid FlowId { get; set; } = Guid.NewGuid();
        public Dictionary<string, IEnumerable<TData>> CurrentData { get; set; } = new Dictionary<string, IEnumerable<TData>>();
    }
}
