using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
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
        public async Task<IActionResult> AddRestaurantCategoriesAsync(Guid restaurantId)
        {
            var categories = this.categoryService.GetAll();
            var selectedCategoryIds = await this.restaurantCategoriesService.GetCategoryIdsForRestaurantAsync(restaurantId);

            var model = new AddCategoryToRestaurantVM
            {
                RestaurantId = restaurantId,
                CategoriesList = categories.ToList(),
            };

            if (selectedCategoryIds.Any())
            {
                model.SelectedCategoriesIds = selectedCategoryIds;
            }

            return View("AddRestaurantCategories", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurantCategoriesAsync(AddCategoryToRestaurantVM model)
        {
            Guid id = await this.restaurantCategoriesService.AddRestaurantCategories(model);

            return RedirectToAction("AssignFeatures", new { restaurantId = id });
        }

        [HttpGet]
        public async Task<IActionResult> EditRestaurantCategoriesAsync(Guid restaurantId)
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

        //[HttpPost]
        //public async Task<IActionResult> EditRestaurantCategoriesAsync(AddCategoryToRestaurantVM model)
        //{
        //    Guid id = await this.restaurantCategoriesService.AddRestaurantCategories(model);
        //    return RedirectToAction(model.NextAction, new { restaurantId = model.RestaurantId });

        //    return RedirectToAction("Index");
        //}
    }
}
