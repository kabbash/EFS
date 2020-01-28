using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Utilities.Models
{
    public interface IPagedResultBase
    {
        int CurrentPage { get; set; }
        int PagesCount { get; set; }
        int PageSize { get; set; }
        int ItmesCount { get; set; }
    }
}
