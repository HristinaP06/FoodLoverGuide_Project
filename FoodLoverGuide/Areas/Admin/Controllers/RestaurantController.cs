using FoodLoverGuide.Areas.Admin.Controllers;
using FoodLoverGuide.Core;
using FoodLoverGuide.Core.Constants;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Views
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService rService;
        private readonly IRestaurantCategoriesService restaurantCategoriesService;
        private readonly ICategoryService categoryService;
        private readonly IFeatureService featureService;
        private readonly IRestaurantFeatureService restaurantFeatureService;
       

        public RestaurantController(IRestaurantService rService,
            IRestaurantCategoriesService restaurantCategoriesService,
            ICategoryService categoryService,
            IFeatureService featureService,
            IRestaurantFeatureService restaurantFeatureService
           )
        {
            this.rService = rService;
            this.restaurantCategoriesService = restaurantCategoriesService;
            this.categoryService = categoryService;
            this.featureService = featureService;
            this.restaurantFeatureService = restaurantFeatureService;
            
        }

        [HttpGet]
        public IActionResult IndexAsync()
        {
            var restaurants = this.rService.GetAllRestaurants().Include(r => r.Reviews).ToList();

            return View(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var restaurant = await this.rService.GetAllRestaurants()
                .Include(rc => rc.RestaurantCategoriesList)
                .ThenInclude(c => c.Category)
                .Include(f => f.Features)
                .ThenInclude(x => x.Features)
                .Include(p => p.Photos)
                .Include(m => m.Menu)
                .Include(r => r.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RestaurantCreateVM model)
        {
            Guid id = await this.rService.AddRestaurant(model);

            return RedirectToAction("AddRestaurantCategories", "RestaurantCategory", new { restaurantId = id });
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id, string nextAction = null)
        {
            var restaurant = await this.rService.GetByIdAsync(id);
            var vm = new RestaurantCreateVM
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Location = restaurant.Location,
                PriceRangeFrom = restaurant.PriceRangeFrom,
                PriceRangeTo = restaurant.PriceRangeTo,
                IndoorCapacity = restaurant.IndoorCapacity,
                OutdoorCapacity = restaurant.OutdoorCapacity,
                Telephone = restaurant.Telephone,
                Email = restaurant.Email,
                Instagram = restaurant.Instagram,
                Facebook = restaurant.Facebook,
                WebSite = restaurant.WebSite,
                NextAction = nextAction
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(RestaurantCreateVM model)
        {
            await this.rService.Update(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction(model.NextAction, new { restaurantId = model.Id });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await this.rService.DeleteRestaurant(id);

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public async Task<IActionResult> AssignCategoriesAsync(Guid restaurantId, string nextAction = null)
        //{
        //    var categories = this.categoryService.GetAll();
        //    var selectedCategoryIds = await this.restaurantCategoriesService.GetCategoryIdsForRestaurantAsync(restaurantId);

        //    var model = new AddCategoryToRestaurantVM
        //    {
        //        RestaurantId = restaurantId,
        //        CategoriesList = categories.ToList(),
        //        NextAction = nextAction,
        //    };

        //    if (selectedCategoryIds.Any())
        //    {
        //        model.SelectedCategoriesIds = selectedCategoryIds;
        //    }
            
        //    return View("AssignCategories", model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AssignCategoriesAsync(AddCategoryToRestaurantVM model)
        //{
        //    Guid id = await this.restaurantCategoriesService.AddRestaurantCategories(model);

        //    if (!string.IsNullOrEmpty(model.NextAction))
        //    {
        //        return RedirectToAction(model.NextAction, new { restaurantId = model.RestaurantId });
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public async Task<IActionResult> AssignFeaturesAsync(Guid restaurantId, string nextAction = null)
        {
            var features = this.featureService.GetAll();
            var selectedFeatureIds = await this.restaurantFeatureService.GetFeatureIdsForRestaurantAsync(restaurantId);

            var model = new AddFeatureToRestaurantVM
            {
                RestaurantId = restaurantId,
                FeaturesList = features.ToList(),
                NextAction = nextAction,
            };

            if (selectedFeatureIds.Any())
            {
                model.SelectedFeaturesIds = selectedFeatureIds;
            }

            return View("AssignFeatures", model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignFeatures(AddFeatureToRestaurantVM model)
        {
            Guid id = await this.restaurantFeatureService.AddRestaurantFeatures(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction(model.NextAction, "WorkTimeSchedule", new { restaurantId = model.RestaurantId });
            }

            return RedirectToAction("Index");
        }

        }
    }
}
