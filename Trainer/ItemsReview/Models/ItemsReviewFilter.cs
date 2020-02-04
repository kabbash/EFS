namespace ItemsReview.Models
{
    public class ItemsReviewFilter
    {
        public string SearchText { get; set; }
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
