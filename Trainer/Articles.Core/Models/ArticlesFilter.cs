namespace Articles.Core.Models
{
    public class ArticlesFilter
    {
        public int Status { get; set; }
        public string SearchText { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int CategoryId { get; set; }
        public string CreatedBy { get; set; }
    }
}
