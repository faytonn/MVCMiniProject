using BusinessLogicLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MVCMiniProject.Models;
using MVCMiniProject.Views.ViewModels;
using System.Diagnostics;

namespace MVCMiniProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISliderService _sliderService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetAllAsync();
            var viewModel = new HomeViewModel
            {
                Sliders = sliders.ToList()
            };

            return View(viewModel);

        }

       
    }
}
