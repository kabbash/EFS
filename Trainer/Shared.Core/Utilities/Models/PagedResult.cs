using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Utilities.Models
{
    public class PagedResult<T> : IPagedResultBase where T : class
    {
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
        public int PageSize { get; set; }
        public int ItmesCount { get; set; }
        public PagedResult()
        {
            Results = new List<T>();
        }
        public IList<T> Results { get; set; }
    }
}
