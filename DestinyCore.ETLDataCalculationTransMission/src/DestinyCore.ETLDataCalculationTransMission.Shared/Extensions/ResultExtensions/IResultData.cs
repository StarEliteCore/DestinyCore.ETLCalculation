using System.Collections.Generic;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Extensions.ResultExtensions
{
    public interface IResultData<TData>
    {
        IEnumerable<TData> Data { get; set; }
    }
}