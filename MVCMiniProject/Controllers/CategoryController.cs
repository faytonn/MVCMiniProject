using AutoMapper;
using BusinessLogicLayer.Repositories.Generic.Abstractions;
using BusinessLogicLayer.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MVCMiniProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService; //DBCONTEXT NIYE BURDADII ne olmalidi c:Niye arxitektura ile yaziriq Repository Service o boyda kod niye var
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.Getp
            return View();
        }
    }
}
