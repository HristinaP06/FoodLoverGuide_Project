using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FoodLoverGuide.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestaurantService rService;

        public HomeController(ILogger<HomeController> logger, IRestaurantService rService)
        {
            _logger = logger;
            this.rService = rService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(string restaurantName = null, bool? isActive = null)
        {
            var restaurants = await rService.GetAllRestaurants(restaurantName, isActive).ToListAsync();

            return View(restaurants);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
