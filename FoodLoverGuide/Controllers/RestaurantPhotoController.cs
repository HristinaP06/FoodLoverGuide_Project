using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Controllers
{
    public class RestaurantPhotoController : Controller
    {
        private readonly IRestaurantPhotoService restaurantPhotoService;

        public RestaurantPhotoController(IRestaurantPhotoService restaurantPhotoService)
        {
            this.restaurantPhotoService = restaurantPhotoService;
        }

        public IActionResult Index()
        {
            var list = this.restaurantPhotoService.GetAll().ToList();

            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestaurantPhoto photo)
        {
            await this.restaurantPhotoService.Add(photo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var obj = this.restaurantPhotoService.GetById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RestaurantPhoto photo)
        {
            await this.restaurantPhotoService.Update(photo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this.restaurantPhotoService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
