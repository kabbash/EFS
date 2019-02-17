using System;

namespace Rating.Core.Models
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public string CurrentUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int EntityTypeId { get; set; }
        public Reviewer Reviwer { get; set; }
    }
}
