using FoodLoverGuide.Core.Constants;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Areas.Admin.Controllers
{
    public class RestaurantCategoryController : BaseController
    {
        private readonly IRestaurantCategoriesService restaurantCategoriesService;
        private readonly ICategoryService categoryService;

        public RestaurantCategoryController(
            IRestaurantCategoriesService restaurantCategoriesService,
            ICategoryService categoryService)
        {
            this.restaurantCategoriesService = restaurantCategoriesService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult AddRestaurantCategories(Guid restaurantId, string nextAction = null)
        {
            var categories = this.categoryService.GetAll();

            var model = new AddCategoryToRestaurantVM
            {
                RestaurantId = restaurantId,
                CategoriesList = categories.ToList(),
                NextAction = nextAction
            };

            return View("AssignRestaurantCategories", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurantCategoriesAsync(AddCategoryToRestaurantVM model)
        {
            Guid id = await this.restaurantCategoriesService.AddRestaurantCategoriesAsync(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction("AddRestaurantFeatures", "RestaurantFeature", new { restaurantId = model.RestaurantId, nextAction = model.NextAction });
            }

            return RedirectToAction("Index", "Restaurant");
        }

        [HttpGet]
        public async Task<IActionResult> EditRestaurantCategoriesAsync(Guid restaurantId, string nextAction = null)
        {
            var allCategories = this.categoryService.GetAll();
            var selectedCategoryIds = await this.restaurantCategoriesService.GetCategoryIdsForRestaurantAsync(restaurantId);

            var vm = new AddCategoryToRestaurantVM
            {
                RestaurantId = restaurantId,
                CategoriesList = allCategories.ToList(),
                SelectedCategoriesIds = selectedCategoryIds,
                NextAction = nextAction
            };

            return View("AssignRestaurantCategories", vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditRestaurantCategoriesAsync(AddCategoryToRestaurantVM model)
        {
            Guid id = await this.restaurantCategoriesService.UpdateRestaurantCategoriesAsync(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction("AddRestaurantFeatures", "RestaurantFeature", new { restaurantId = id });
            }

            TempData[MessageConstants.SuccessMessage] = "Успешна редакация!";

            return RedirectToAction("Index", "Restaurant");
        }
    }
}
