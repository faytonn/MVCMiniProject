﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.Product
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
