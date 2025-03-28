﻿using FoodLoverGuide.Areas.Admin.Controllers;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Views
{
    public class RestaurantPhotoController : BaseController
    {
        private readonly IRestaurantPhotoService restaurantPhotoService;
        private readonly IRestaurantService restaurantService;

        public RestaurantPhotoController(IRestaurantPhotoService restaurantPhotoService, IRestaurantService restaurantService)
        {
            this.restaurantPhotoService = restaurantPhotoService;
            this.restaurantService = restaurantService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var list = await this.restaurantPhotoService.GetAll().ToListAsync();

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid restaurantId)
        {
            var restaurant = await this.restaurantService.GetByIdAsync(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            var model = new AddPhotoRestaurantVM
            {
                RestaurantId = restaurant.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddPhotoRestaurantVM model)
        {
            if (model.Photos != null && model.Photos.Any())
            {
                foreach (var url in model.Photos)
                {
                    await this.restaurantPhotoService.AddRestaurantPhoto(model.RestaurantId, null, url);
                }
            }

            if (model.Files != null && model.Files.Any())
            {
                foreach (var file in model.Files)
                {
                    await this.restaurantPhotoService.AddRestaurantPhoto(model.RestaurantId, file, null);
                }
            }
            return RedirectToAction("Create", "MenuItem", new { restaurantId = model.RestaurantId});
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var obj = await this.restaurantPhotoService.GetById(id);
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
