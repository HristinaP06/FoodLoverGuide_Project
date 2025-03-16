using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var list = await this.reviewService.GetAll().ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Review review)
        {
            await this.reviewService.Add(review);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var obj = await reviewService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Review review)
        {
            await this.reviewService.Update(review);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await this.reviewService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
