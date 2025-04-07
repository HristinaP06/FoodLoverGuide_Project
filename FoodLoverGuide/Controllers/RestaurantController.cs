using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.Services;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Core.ViewModels.UserArea;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FoodLoverGuide.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;
        private readonly ICategoryService categoryService;
        private readonly IFeatureService featureService;
        

        public RestaurantController(IRestaurantService restaurantService, 
            ICategoryService categoryService, 
            IFeatureService featureService)
        {
            this.restaurantService = restaurantService;
            this.categoryService = categoryService;
            this.featureService = featureService;
        }

        public async Task<IActionResult> Index(
            string[] categoryIds = null,
            string[] featureIds = null,
            string priceRange = null,
            string rating = null)
        {
            var list = await this.restaurantService.GetRestaurantsWithFilters(categoryIds, featureIds, priceRange, rating).ToListAsync();

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

        public IActionResult Details(Guid id)
        {
            var restaurants = this.restaurantService.GetAllRestaurants()
                .Include(p => p.Photos)
                .Include(f => f.Features)
                .ThenInclude(x => x.Features)
                .Include(c => c.RestaurantCategoriesList)
                .ThenInclude(y => y.Category)
                .Include(w => w.WorkTime)
                .Include(m => m.Menu)
                .Include(re => re.Reviews)
                .ThenInclude(r => r.User);

           var restaurant = restaurants.Where(r => r.Id == id).FirstOrDefault();
            return View(restaurant);
        }

        
    }
}
