using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            var list = this.reviewService.GetAll().ToList();
            return View(list);
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Review review)
        {
            await this.reviewService.Add(review);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
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
