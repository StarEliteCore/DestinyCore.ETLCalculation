using System.Collections.Generic;

namespace DestinyCore.ETLDispatchCenter.Shared.Extensions.ResultExtensions
{
    public interface IResultData<TData>
    {
        IEnumerable<TData> Data { get; set; }
    }
}