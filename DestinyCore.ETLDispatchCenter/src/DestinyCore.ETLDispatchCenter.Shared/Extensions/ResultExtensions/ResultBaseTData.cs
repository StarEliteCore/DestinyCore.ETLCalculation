using System.Collections.Generic;

namespace DestinyCore.ETLDispatchCenter.Shared.Extensions.ResultExtensions
{
    public abstract class ResultBaseTData<TData> : ResultBase, IResultData<TData>
    {
        public virtual IEnumerable<TData> Data { get; set; }
    }
}