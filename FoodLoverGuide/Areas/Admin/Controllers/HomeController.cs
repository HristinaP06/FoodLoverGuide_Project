using System.Diagnostics;
using FoodLoverGuide.Core.Constants;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> IndexAsync()
        {
            var restaurants = await rService.GetAllRestaurants().ToListAsync();

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
