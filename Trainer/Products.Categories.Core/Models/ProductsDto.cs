﻿using Attachments.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Products.Core.Models
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ExpDate { get; set; }        
        public decimal Price { get; set; }
        public string ProfilePicture { get; set; }
        public IFormFile ProfilePictureFile { get; set; }
        public List<SliderItemDto> Images { get; set; }
        public List<SliderItemDto> UpdatedImages { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool IsSpecial { get; set; }
        public decimal Rate { get; set; }
        public SellerInfo Seller { get; set; }
        public string PhoneNumber { get; set; }
    }
}
