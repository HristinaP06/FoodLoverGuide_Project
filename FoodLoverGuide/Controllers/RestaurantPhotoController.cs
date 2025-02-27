using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class RestaurantPhotoController : Controller
    {
        private readonly IRestaurantPhotoService restaurantPhotoService;

        public RestaurantPhotoController(IRestaurantPhotoService restaurantPhotoService)
        {
            this.restaurantPhotoService = restaurantPhotoService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var list = await this.restaurantPhotoService.GetAll().ToListAsync();

            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RestaurantPhoto photo)
        {
            await this.restaurantPhotoService.Add(photo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var obj = this.restaurantPhotoService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(RestaurantPhoto photo)
        {
            await this.restaurantPhotoService.Update(photo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await this.restaurantPhotoService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
