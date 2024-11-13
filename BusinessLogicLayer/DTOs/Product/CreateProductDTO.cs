using BusinessLogicLayer.DTOs.Category;
using BusinessLogicLayer.DTOs.Tag;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.DTOs.Product
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO? Category { get; set; }
        public List<string> ProductImages { get; set; } = new List<string>();
        public List<string> ProductTags { get; set; } = new List<string>();
        public List<IFormFile> MainImage { get; set; }
        public List<IFormFile> SecondaryImages { get; set; } = [];
        public List<TagDTO> Tags { get; set; }
    }
}
