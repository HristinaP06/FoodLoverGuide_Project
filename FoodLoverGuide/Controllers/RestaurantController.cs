using FoodLoverGuide.Core;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService rService;
        private readonly IRestaurantCategoriesService restaurantCategoriesService;
        private readonly ICategoryService categoryService;
        private readonly IFeatureService featureService;

        public RestaurantController(IRestaurantService rService, 
            IRestaurantCategoriesService restaurantCategoriesService,
            ICategoryService categoryService,
            IFeatureService featureService)
        {
            this.rService = rService;
            this.restaurantCategoriesService = restaurantCategoriesService;
            this.categoryService = categoryService;
            this.featureService = featureService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var rest = await this.rService.GetAllRestaurants().Include(x => x.Features).Include(x => x.RestaurantCategoriesList).ToListAsync();
            var model = rest.Select(r => new RestaurantCreateVM
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Location = r.Location,
                PriceRangeFrom = r.PriceRangeFrom,
                PriceRangeTo = r.PriceRangeTo,
                IndoorCapacity = r.IndoorCapacity,
                OutdoorCapacity = r.OutdoorCapacity,
                Telephone = r.Telephone,
                Email = r.Email,
                Instagram = r.Instagram,
                Facebook = r.Facebook,
                WebSite = r.WebSite
            });
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(RestaurantCreateVM model)
        {
            Guid id = await this.rService.AddRestaurant(model);

            return RedirectToAction("AssignCategories", new { restaurantId = id });
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var obj = await this.rService.GetById(id);
            var vm = new RestaurantCreateVM
            {
                Name = obj.Name,
                Description = obj.Description,
                Location = obj.Location,
                PriceRangeFrom = obj.PriceRangeFrom,
                PriceRangeTo = obj.PriceRangeTo,
                IndoorCapacity = obj.IndoorCapacity,
                OutdoorCapacity = obj.OutdoorCapacity,
                Telephone = obj.Telephone,
                Email = obj.Email,
                Instagram = obj.Instagram,
                Facebook = obj.Facebook,
                WebSite = obj.WebSite
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(RestaurantCreateVM model)
        {
            await this.rService.Update(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await this.rService.DeleteRestaurant(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AssignCategories(Guid restaurantId)
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
            await this.restaurantCategoriesService.AddRestaurantCategories(model);
            return RedirectToAction("AssignFeatures", model.RestaurantId);
        }

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
    }
}
