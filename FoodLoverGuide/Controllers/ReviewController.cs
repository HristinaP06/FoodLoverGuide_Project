using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.User;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FoodLoverGuide.Controllers
{
    public class ReviewController : BaseController
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
        public async Task<IActionResult> CreateAsync(Guid restaurantId, double rating, string description)
        {
            var userId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var newReview = new Review
            {
                Id = Guid.NewGuid(),
                Rating = rating,
                Description = string.IsNullOrEmpty(description) ? null : description, 
                RestaurantId = restaurantId,
                UserId = userId
            };
            await this.reviewService.Add(newReview);

            return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var obj = await reviewService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Review review)
        {
            await this.reviewService.Update(review);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAsync(Guid reviewId, Guid restaurantId)
        {
            var userId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            var review = await reviewService.GetById(reviewId);
            if (review == null || review.UserId != userId)
            {
                return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
            }

            await reviewService.Delete(reviewId);
            return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
        }

    }
}
