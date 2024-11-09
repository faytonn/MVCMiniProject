using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCMiniProject.DataAccessLayer;

namespace MVCMiniProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly AppDBContext _dbContext;
        public ProductController(AppDBContext context)
        {
            _dbContext = context;
        }

    }
}
