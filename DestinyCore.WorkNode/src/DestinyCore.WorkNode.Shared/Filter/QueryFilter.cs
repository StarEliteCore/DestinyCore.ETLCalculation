using DestinyCore.WorkNode.Shared.Enums;
using System.Collections.Generic;

namespace DestinyCore.WorkNode.Shared.Filter
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