using System.Collections.Generic;

namespace Destiny.Core.TaskScheduler.Shared.Extensions.ResultExtensions
{
    public interface IListResult<T> : IResultBase
    {
        IReadOnlyList<T> Data { get; set; }
    }
}