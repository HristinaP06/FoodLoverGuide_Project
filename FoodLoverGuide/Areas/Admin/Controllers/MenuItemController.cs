using FoodLoverGuide.Areas.Admin.Controllers;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.MenuItem;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Views
{
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemService menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            this.menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(Guid restaurantId)
        {
            var list =  await this.menuItemService.GetAll().Where(p => p.RestaurantId == restaurantId).ToListAsync();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddPhotoRestaurantVM model)
        {
            
            if (model.Photos != null && model.Photos.Any())
            {
                foreach (var url in model.Photos)
                {
                    await this.menuItemService.AddRestaurantPhoto(model.RestaurantId, null, url);
                }
            }
            if (model.Files != null && model.Files.Any())
            {
                foreach (var file in model.Files)
                {
                    await this.menuItemService.AddRestaurantPhoto(model.RestaurantId, file, null);
                }
            }
            return RedirectToAction("Index", "Restaurant");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var menuItem = await this.menuItemService.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            var model = new EditMenuItemPhotoVM
            {
                Id = menuItem.Id,
                RestaurantId = menuItem.RestaurantId,
                CurrentMenuPhotoUrl = menuItem.Photo
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditMenuItemPhotoVM model)
        {
            await this.menuItemService.UpdateMenuItemPhotoAsync(model.Id, model.NewFile, model.NewUrl);
            return RedirectToAction("Index", new { model.RestaurantId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id, Guid restaurantId)
        {
            await this.menuItemService.Delete(id);
            return RedirectToAction("Index", new { restaurantId });
        }
    }
}
