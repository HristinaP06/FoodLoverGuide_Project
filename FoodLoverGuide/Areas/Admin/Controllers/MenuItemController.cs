using FoodLoverGuide.Areas.Admin.Controllers;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.MenuItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Views
{
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemService menuItemService;
        private readonly IRestaurantService restaurantService;

        public MenuItemController(IMenuItemService menuItemService, IRestaurantService restaurantService)
        {
            this.menuItemService = menuItemService;
            this.restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(Guid restaurantId)
        {
            var list =  await this.menuItemService
                .GetAll()
                .Where(p => p.RestaurantId == restaurantId)
                .ToListAsync();

            var vm = new MenuItemsVM
            {
                RestaurantId = restaurantId,
                MenuItems = list,
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid restaurantId, string nextAction = null)
        {
            var restaurant = await this.restaurantService.GetByIdAsync(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            var model = new AddRestaurantMenuItemVM
            {
                RestaurantId = restaurant.Id,
                NextAction = nextAction,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddRestaurantMenuItemVM model)
        {
            if (model.MenuPhotos != null && model.MenuPhotos.Any())
            {
                int order = 0;
                foreach (var url in model.MenuPhotos)
                {
                    await this.menuItemService.AddRestaurantMenuPhotoAsync(model.RestaurantId, null, url, order++);
                }
            }
            if (model.Files != null && model.Files.Any())
            {
                int order = 0;
                foreach (var file in model.Files)
                {
                    await this.menuItemService.AddRestaurantMenuPhotoAsync(model.RestaurantId, file, null, order++);
                }
            }

            if (!string.IsNullOrEmpty(model.NextAction) && model.NextAction == "Index")
            {
                return RedirectToAction("Index", new { model.RestaurantId });
            }
            else
            {
                return RedirectToAction("Index", "Restaurant");
            }
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
