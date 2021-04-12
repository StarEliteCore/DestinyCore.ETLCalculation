using System.Collections.Generic;

namespace DestinyCore.WorkNode.Shared.Extensions.ResultExtensions
{
    public interface IResultData<TData>
    {
        IEnumerable<TData> Data { get; set; }
    }
}