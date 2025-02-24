using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var list  = await this.service.GetAll().ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await this.service.Add(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await this.service.GetById(id);
            return View(obj);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            await this.service.Update(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
