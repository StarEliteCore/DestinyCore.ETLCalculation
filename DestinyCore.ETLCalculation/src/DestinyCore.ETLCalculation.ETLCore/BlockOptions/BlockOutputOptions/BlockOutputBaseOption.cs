using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockOutputOptions
{
    public class BlockOutputBaseOption : IBlockOutputOption
    {
        public BlockOutputBaseOption()
        {
            Data = new Dictionary<string, object>();
        }
        public Guid NodeId { get; set; }
        public Guid FlowId { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}
