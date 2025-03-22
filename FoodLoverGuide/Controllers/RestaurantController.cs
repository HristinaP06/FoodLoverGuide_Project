using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Core.ViewModels.User;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;
        private readonly ICategoryService categoryService;
        private readonly IFeatureService featureService;

        public RestaurantController(IRestaurantService restaurantService, ICategoryService categoryService, IFeatureService featureService)
        {
            this.restaurantService = restaurantService;
            this.categoryService = categoryService;
            this.featureService = featureService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await this.restaurantService.GetAllRestaurants()
                .Include(c => c.RestaurantCategoriesList)
                .ThenInclude(y => y.Category)
                .Include(f => f.Features)
                .ThenInclude(x => x.Features)
                .Include(r => r.RatingList)
                .Include(p => p.Photos)
                .ToListAsync();
            var catList = await this.categoryService.GetAll().ToListAsync();
            var featList = await this.featureService.GetAll().ToListAsync();

            var index = new RestaurantIndexVM
            {
                Restaurants = list,
                Categories = catList,
                Features = featList,
            };
            return View(index);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var restaurants = this.restaurantService.GetAllRestaurants()
                .Include(r => r.RatingList)
                .Include(p => p.Photos)
                .Include(f => f.Features)
                .ThenInclude(x => x.Features)
                .Include(c => c.RestaurantCategoriesList)
                .ThenInclude(y => y.Category)
                .Include(w => w.WorkTime)
                .Include(m => m.Menu);
           var restaurant = restaurants.Where(r => r.Id == id).FirstOrDefault();
            return View(restaurant);
        }

    }
}
