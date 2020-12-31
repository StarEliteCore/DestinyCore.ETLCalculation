using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.Shared.Extensions.ResultExtensions
{
    public interface IListResult<T> : IResultBase
    {
        IReadOnlyList<T> Data { get; set; }
    }
}