namespace Products.Core.Models
{
    public class ProductFilter
    {
        public ProductStatusEnum Status { get; set; }
        public string SearchText { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public bool? IsSpecial { get; set; }
    }
}
