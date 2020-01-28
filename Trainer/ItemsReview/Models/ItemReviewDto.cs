using Microsoft.AspNetCore.Http;
using Rating.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsReview.Models
{
    public class ItemReviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public List<RatingDto> Reviews { get; set; }
    }
}
