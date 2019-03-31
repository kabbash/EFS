using System;
using System.Collections.Generic;
using System.Text;

namespace Neutrints.Core.Models
{
    public class FoodIemFilter
    {
        public string SearchText { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
