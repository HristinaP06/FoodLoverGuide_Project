using FoodLoverGuide.Areas.Admin.Controllers;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Core.ViewModels.RestaurantPhoto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Views
{
    public class RestaurantPhotoController : BaseController
    {
        private readonly IRestaurantPhotoService restaurantPhotoService;
        private readonly IRestaurantService restaurantService;

        public RestaurantPhotoController(IRestaurantPhotoService restaurantPhotoService, IRestaurantService restaurantService)
        {
            this.restaurantPhotoService = restaurantPhotoService;
            this.restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(Guid restaurantId)
        {
            var list = await this.restaurantPhotoService.GetAll().Where(p => p.RestaurantId == restaurantId).ToListAsync();

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid restaurantId)
        {
            var restaurant = await this.restaurantService.GetByIdAsync(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            var model = new AddPhotoRestaurantVM
            {
                RestaurantId = restaurant.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddPhotoRestaurantVM model)
        {
            if (model.Photos != null && model.Photos.Any())
            {
                foreach (var url in model.Photos)
                {
                    await this.restaurantPhotoService.AddRestaurantPhotoAsync(model.RestaurantId, null, url);
                }
            }

            if (model.Files != null && model.Files.Any())
            {
                foreach (var file in model.Files)
                {
                    await this.restaurantPhotoService.AddRestaurantPhotoAsync(model.RestaurantId, file, null);
                }
            }
            return RedirectToAction("Create", "MenuItem", new { restaurantId = model.RestaurantId});
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var photo = await restaurantPhotoService.GetById(id);
            if (photo == null)
            {
                return NotFound();
            }

            var model = new EditPhotoRestaurantVM
            {
                Id = photo.Id,
                RestaurantId = photo.RestaurantId,
                CurrentPhotoUrl = photo.Photo
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditAsync(EditPhotoRestaurantVM model)
        {
            await this.restaurantPhotoService.UpdateRestaurantPhotoAsync(model.Id, model.NewFile, model.NewUrl);
            return RedirectToAction("Index", new { model.RestaurantId });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id, Guid restaurantId)
        {
            await this.restaurantPhotoService.Delete(id);
            return RedirectToAction("Index", new { restaurantId });
        }
    }
}
