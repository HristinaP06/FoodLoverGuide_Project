using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            this.menuItemService = menuItemService;
        }

        public async Task<IActionResult> Index()
        {
            var list =  this.menuItemService.GetAll().ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItem menu)
        {
            await this.menuItemService.Add(menu);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await this.menuItemService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MenuItem menuItem)
        {
            await this.menuItemService.Update(menuItem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.menuItemService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
