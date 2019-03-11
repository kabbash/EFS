using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Models
{
    public class UsersFilter
    {
        public string SearchText { get; set; }
        public string Role { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public bool? IsBlocked { get; set; }
    }
}
