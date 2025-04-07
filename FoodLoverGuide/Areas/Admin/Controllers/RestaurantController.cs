using FoodLoverGuide.Areas.Admin.Controllers;
using FoodLoverGuide.Core;
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

            return RedirectToAction("AssignCategories", new { restaurantId = id, step = 2 });
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id, int? step)
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
                WebSite = restaurant.WebSite
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(RestaurantCreateVM model, string step)
        {
            await this.rService.Update(model);

            if (!string.IsNullOrEmpty(step))
            {
                return RedirectToAction("AssignCategories");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await this.rService.DeleteRestaurant(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AssignCategories(Guid restaurantId, int? step = null)
        {
            var categories = this.categoryService.GetAll();
            var model = new AddCategoryToRestaurantVM
            {
                RestaurantId = restaurantId,
                CategoriesList = categories.ToList(),
            };

            return View("AssignCategories", model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignCategories(AddCategoryToRestaurantVM model)
        {
            Guid id = await this.restaurantCategoriesService.AddRestaurantCategories(model);

            return RedirectToAction("AssignFeatures", new { restaurantId = id, step = 3 });
        }

        [HttpGet]
        public async Task<IActionResult> EditCategoriesAsync(Guid restaurantId, int? step = null)
        {
            var allCategories = this.categoryService.GetAll();
            var selectedCategoryIds = await this.restaurantCategoriesService.GetCategoryIdsForRestaurantAsync(restaurantId);

            var vm = new AddCategoryToRestaurantVM
            {
                RestaurantId = restaurantId,
                CategoriesList = allCategories.ToList(),
                SelectedCategoriesIds = selectedCategoryIds
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAssignedCategories(AddCategoryToRestaurantVM model)
        {
            Guid id = await this.restaurantCategoriesService.AddRestaurantCategories(model);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> EditCategoriesAsync(AddCategoryToRestaurantVM model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // repopulate the list if validation fails
        //        model.CategoriesList = await cService.GetAllAsync();
        //        return View(model);
        //    }

        //    await cService.AssignCategoriesAsync(model.RestaurantId, model.SelectedCategoriesIds);
        //    return RedirectToAction("Edit", new { id = model.RestaurantId, step = 3 }); // or wherever Step 3 is
        //}

        [HttpGet]
        public IActionResult AssignFeatures(Guid restaurantId)
        {
            var features = this.featureService.GetAll();
            var model = new AddFeatureToRestaurantVM
            {
                RestaurantId = restaurantId,
                FeaturesList = features.ToList(),
            };
            return View("AssignFeatures", model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignFeatures(AddFeatureToRestaurantVM model)
        {
            Guid id = await this.restaurantFeatureService.AddRestaurantFeatures(model);

            return RedirectToAction("Create", "WorkTimeSchedule", new { restaurantId = id });
        }
    }
}
