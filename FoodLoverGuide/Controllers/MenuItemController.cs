using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            this.menuItemService = menuItemService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var list =  await this.menuItemService.GetAll().ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(MenuItem menu)
        {
            await this.menuItemService.Add(menu);

            return RedirectToAction("Index");
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
