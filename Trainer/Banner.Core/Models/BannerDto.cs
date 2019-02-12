using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banner.Core.Models
{
    public class BannerDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string ButtonUrl { get; set; }
        public string ButtonText { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
