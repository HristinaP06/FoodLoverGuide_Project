using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService menuItemService;
        private readonly IRestaurantService restaurantService;

        public MenuItemController(IMenuItemService menuItemService, IRestaurantService restaurantService)
        {
            this.menuItemService = menuItemService;
            this.restaurantService = restaurantService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var list =  await this.menuItemService.GetAll().ToListAsync();
            return View(list);
        }

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
            await this.menuItemService.AddRestaurantPhoto(model);
            return RedirectToAction("Index", "Restaurant");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var obj = await this.menuItemService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(MenuItem menuItem)
        {
            await this.menuItemService.Update(menuItem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await this.menuItemService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
