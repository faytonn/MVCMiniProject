using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCMiniProject.DataAccessLayer;

namespace MVCMiniProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBContext _dbContext;

        public CategoryController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();
            return View();
        }
    }
}
