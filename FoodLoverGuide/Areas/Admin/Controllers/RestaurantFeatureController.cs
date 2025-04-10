using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Areas.Admin.Controllers
{
    public class RestaurantFeatureController : BaseController
    {
        private readonly IRestaurantFeatureService restaurantFeatureService;
        private readonly IFeatureService featureService;

        public RestaurantFeatureController(
            IRestaurantFeatureService restaurantFeatureService,
            IFeatureService featureService)
        {
            this.restaurantFeatureService = restaurantFeatureService;
            this.featureService = featureService;

        }

        [HttpGet]
        public IActionResult AddRestaurantFeatures(Guid restaurantId)
        {
            var features = this.featureService.GetAll();

            var model = new AddFeatureToRestaurantVM
            {
                RestaurantId = restaurantId,
                FeaturesList = features.ToList(),
            };

            return View("AssignRestaurantFeatures", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurantFeaturesAsync(AddFeatureToRestaurantVM model)
        {
            Guid id = await this.restaurantFeatureService.AddRestaurantFeatures(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction(model.NextAction, "WorkTimeSchedule", new { restaurantId = model.RestaurantId });
            }

            return RedirectToAction("Index", "Restaurant");
        }

        [HttpGet]
        public async Task<IActionResult> EditRestaurantFeaturesAsync(Guid restaurantId, string nextAction = null)
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

            return View("AssignRestaurantFeatures", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRestaurantFeaturesAsync(AddFeatureToRestaurantVM model)
        {
            Guid id = await this.restaurantFeatureService.UpdateRestaurantFeaturesAsync(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction(model.NextAction, "WorkTimeSchedule", new { restaurantId = id });
            }

            return RedirectToAction("Index", "Restaurant");
        }
    }
}
