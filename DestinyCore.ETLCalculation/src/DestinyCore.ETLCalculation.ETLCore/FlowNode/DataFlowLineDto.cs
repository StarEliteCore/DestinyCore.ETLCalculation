using System;
using System.ComponentModel;

namespace DestinyCore.ETLCalculation.ETLCore.FlowNode
{
    public class DataFlowLineDto
    {
        /// <summary>
        /// 源节点Id对象
        /// </summary>
        [DisplayName("源节点Id对象")]
        public CellPortEntity Source { get; set; }
        /// <summary>
        /// 目标节点Id
        /// </summary>
        [DisplayName("目标节点Id")]
        public CellPortEntity Target { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [DisplayName("")]
    public class CellPortEntity
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public Guid Cell { get; set; }
        /// <summary>
        /// 链接桩Id
        /// </summary>
        public Guid Port { get; set; }
    }
}
