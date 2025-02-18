using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var list  = await _service.GetAll().ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _service.Add(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = await _service.GetById(id);
            return View(obj);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            await _service.Update(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RestaurantCreate()
        {
            var list = await _service.GetAll().ToListAsync();
            return RedirectToAction("RestaurantCreate");
        }
    }
}
