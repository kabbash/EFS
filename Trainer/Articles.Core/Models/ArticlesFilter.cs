namespace Articles.Core.Models
{
    public class ArticlesFilter
    {
        public int Status { get; set; }
        public string SearchText { get; set; }
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int CategoryId { get; set; }
        public string CreatedBy { get; set; }
    }
}
