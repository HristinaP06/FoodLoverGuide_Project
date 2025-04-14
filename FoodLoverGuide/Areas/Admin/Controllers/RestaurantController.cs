using FoodLoverGuide.Areas.Admin.Controllers;
using FoodLoverGuide.Core.Constants;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Views
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService restaurantService;
       
        public RestaurantController(IRestaurantService rService)
        {
            this.restaurantService = rService;
        }

        [HttpGet]
        public IActionResult IndexAsync()
        {
            var restaurants = this.restaurantService.GetAllRestaurants().Include(r => r.Reviews).ToList();

            return View(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var restaurant = await this.restaurantService.GetAllRestaurants()
                .Include(rc => rc.RestaurantCategoriesList)
                .ThenInclude(c => c.Category)
                .Include(f => f.Features)
                .ThenInclude(x => x.Features)
                .Include(w => w.WorkTime)
                .Include(p => p.Photos)
                .Include(m => m.Menu)
                .Include(r => r.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RestaurantCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешно създаване!";
                return View(model);
            }

            Guid id = await this.restaurantService.AddRestaurantAsync(model);

            return RedirectToAction("AddRestaurantCategories", "RestaurantCategory", new
            {
                restaurantId = id,
                nextAction = "AddRestaurantCategories",
            });
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id, string nextAction = null)
        {
            Restaurant restaurant = await this.restaurantService.GetByIdAsync(id);

            if (restaurant == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Не успяхме да открием този ресторант!";
                return RedirectToAction("Index");
            }

            RestaurantCreateVM vm = new RestaurantCreateVM
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Location = restaurant.Location,
                PriceRangeFrom = restaurant.PriceRangeFrom,
                PriceRangeTo = restaurant.PriceRangeTo,
                IndoorCapacity = restaurant.IndoorCapacity,
                OutdoorCapacity = restaurant.OutdoorCapacity,
                Telephone = restaurant.Telephone,
                Email = restaurant.Email,
                Instagram = restaurant.Instagram,
                Facebook = restaurant.Facebook,
                WebSite = restaurant.WebSite,
                NextAction = nextAction
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(RestaurantCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешна редакция!";
                return View(model);
            }

            await this.restaurantService.UpdateAsync(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction("AddRestaurantCategories", "RestaurantCategory", new
                {
                    restaurantId = model.Id,
                    nextAction = model.NextAction
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await this.restaurantService.DeleteRestaurantAsync(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ActivateAsync(Guid id)
        {
            var restaurant = await this.restaurantService.GetByIdWithIncludesAsync(id);
            if (restaurant == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Не е намерен такъв ресторант!";
                return RedirectToAction("Index", "Home");
            }

            if (!restaurant.IndoorCapacity.HasValue || !restaurant.OutdoorCapacity.HasValue)
            {
                TempData[MessageConstants.ErrorMessage] = "Ресторанта трябва да има въведен вътрешен и външен капацитет!";
                return RedirectToAction("Index", "Home");
            }

            if (!restaurant.RestaurantCategoriesList.Any())
            {
                TempData[MessageConstants.ErrorMessage] = "Ресторанта трябва да има поне 1 категория!";
                return RedirectToAction("Index", "Home");
            }

            if (!restaurant.Features.Any())
            {
                TempData[MessageConstants.ErrorMessage] = "Ресторанта трябва да има поне 1 характеристика!";
                return RedirectToAction("Index", "Home");
            }

            var invalidWorkTime = restaurant.WorkTime
                .Where(w => !w.IsClosed)
                .Any(w => w.OpeningTime == TimeSpan.Zero && w.ClosingTime == TimeSpan.Zero);

            if (invalidWorkTime)
            {
                TempData[MessageConstants.ErrorMessage] = "Всички дни, в които ресторантът работи трябва да имат зададени часове на отваряне и затваряне!";
                return RedirectToAction("Index", "Home");
            }

            await this.restaurantService.ActivateAsync(restaurant);

            if (restaurant.IsActive)
            {
                TempData[MessageConstants.SuccessMessage] = "Статуса на ресторанта е успешно променен!";
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateAsync(Guid id)
        {
            var restaurant = await this.restaurantService.GetByIdAsync(id);
            if (restaurant == null)
            {
                TempData[MessageConstants.ErrorMessage] = "Не е намерен такъв ресторант!";
                return RedirectToAction("Index", "Home");
            }

            await this.restaurantService.DeactivateAsync(restaurant);

            if (!restaurant.IsActive)
            {
                TempData[MessageConstants.SuccessMessage] = "Статуса на ресторанта е успешно променен!";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
