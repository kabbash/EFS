using Shared.Core.Utilities.Enums;

namespace Products.Core.Models
{
    public class ProductFilter
    {
        public StatusFilterEnum Status { get; set; }
        public string SearchText { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public bool? IsSpecial { get; set; }
        public int CategoryId { get; set; }
        public string CreatedBy { get; set; }
    }
}
