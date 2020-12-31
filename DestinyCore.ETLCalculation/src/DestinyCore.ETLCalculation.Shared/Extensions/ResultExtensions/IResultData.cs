using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.Shared.Extensions.ResultExtensions
{
    public interface IResultData<TData>
    {
        IEnumerable<TData> Data { get; set; }
    }
}