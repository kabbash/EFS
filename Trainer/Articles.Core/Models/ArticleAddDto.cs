namespace Articles.Core.Models
{
    public class ArticleAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ProfilePicture { get; set; }
    }
}
