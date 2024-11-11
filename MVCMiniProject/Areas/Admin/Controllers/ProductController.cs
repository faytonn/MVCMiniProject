using AutoMapper;
using BusinessLogicLayer.DTOs.Product;
using BusinessLogicLayer.DTOs.ProductImage;
using BusinessLogicLayer.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCMiniProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IWebHostEnvironment env, IProductImageService productImageService, IMapper mapper)
        {
            _productService = productService;
            _env = env;
            _productImageService = productImageService;
            _mapper = mapper;

        }



        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var createdProduct = _productService.AddProductAsync(dto);

            foreach (var file in dto.Files)
            {
                if (file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads/products");
                    Directory.CreateDirectory(uploadsFolder);
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var productImageDto = new CreateProductImageDTO
                    {
                        ProductId = createdProduct.Id,
                        ImageUrl = "/uploads/products/" + uniqueFileName,
                        IsMain = false
                    };

                    await _productImageService.CreateAsync(productImageDto);
                }
            }

            await _productService.AddProductAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            foreach (var file in dto.Files)
            {
                if (file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads/products");
                    Directory.CreateDirectory(uploadsFolder);
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var productImageDto = new CreateProductImageDTO
                    {
                        ProductId = dto.Id,
                        ImageUrl = "/uploads/products/" + uniqueFileName,
                        IsMain = false
                    };

                    await _productImageService.CreateAsync(productImageDto);
                }
            }

            await _productService.UpdateProductAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            foreach (var image in product.Images)
            {
                string imagePath = Path.Combine(_env.WebRootPath, image.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
