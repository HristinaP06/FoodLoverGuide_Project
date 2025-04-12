using System.Diagnostics;
using FoodLoverGuide.Core.Constants;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.UserArea;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestaurantService restaurantService;

        public HomeController(ILogger<HomeController> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            this.restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var restaurants = await this.restaurantService
                .GetAllRestaurants()
                .Include(r => r.Reviews)
                .ThenInclude(r => r.User)
                .Include(r => r.Photos)
                .ToListAsync();

            var latestReviews = restaurants
                .SelectMany(r => r.Reviews ?? new List<Review>())
                .Take(3)
                .ToList();

            var featuredPhotos = restaurants
                .SelectMany(r => r.Photos ?? new List<RestaurantPhoto>())
                .Where(p => !string.IsNullOrEmpty(p.Photo))
                .Take(6)
                .ToList();

            var model = new HomeVM
            {
                Restaurants = restaurants
                    .Where(r => (r.Reviews.Count > 0 && (r.Reviews.Select(x => x.Rating).Sum() / r.Reviews.Count) <= 5))
                    .Take(3)
                    .ToList(),
                RestaurantsCount = restaurants.Count,
                LatestReviews = latestReviews,
                FeaturedPhotos = featuredPhotos
            };

            return View(model);
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
