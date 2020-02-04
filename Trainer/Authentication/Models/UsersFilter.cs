using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class UsersFilter
    {
        public string SearchText { get; set; }
        public string Role { get; set; }
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool? IsBlocked { get; set; }
    }
}
