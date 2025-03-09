using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Category;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var list = await this.categoryService.GetAll().ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(NewCategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category newCategory = new Category()
            {
                CategoryName = category.Name,
            };

            await this.categoryService.Add(newCategory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var obj = await this.categoryService.GetById(id);
            return View(obj);
        }


        [HttpPost]
        public async Task<IActionResult> EditAsync(Category category)
        {
            await this.categoryService.Update(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await this.categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
