using Destiny.Core.TaskScheduler.Shared.Enums;
using System.Collections.Generic;

namespace Destiny.Core.TaskScheduler.Shared.Filter
{
    public class QueryFilter
    {
        public QueryFilter()
        {
        }

        public QueryFilter(FilterConnect filterConnect, List<FilterCondition> filters)
        {
            this.FilterConnect = filterConnect;
            this.Filters = filters;
        }

        /// <summary>
        /// 查询条件and或者Or
        /// </summary>
        public FilterConnect FilterConnect { get; set; } = FilterConnect.And;

        public List<FilterCondition> Filters { get; set; } = new List<FilterCondition>();
    }
}