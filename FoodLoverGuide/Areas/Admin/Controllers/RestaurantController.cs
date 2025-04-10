using FoodLoverGuide.Areas.Admin.Controllers;
using FoodLoverGuide.Core.Constants;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Areas.Admin.Views
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService rService;
       
        public RestaurantController(IRestaurantService rService)
        {
            this.rService = rService;
        }

        [HttpGet]
        public IActionResult IndexAsync()
        {
            var restaurants = this.rService.GetAllRestaurants().Include(r => r.Reviews).ToList();

            return View(restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var restaurant = await this.rService.GetAllRestaurants()
                .Include(rc => rc.RestaurantCategoriesList)
                .ThenInclude(c => c.Category)
                .Include(f => f.Features)
                .ThenInclude(x => x.Features)
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
            Guid id = await this.rService.AddRestaurant(model);

            return RedirectToAction("AssignRestaurantCategories", "RestaurantCategory", new { restaurantId = id });
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id, string nextAction = null)
        {
            var restaurant = await this.rService.GetByIdAsync(id);
            var vm = new RestaurantCreateVM
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
            await this.rService.Update(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction(model.NextAction, new { restaurantId = model.Id });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await this.rService.DeleteRestaurant(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ActivateAsync(Guid id)
        {
            var restaurant = await this.rService.GetByIdAsync(id);
            if (restaurant == null)
            {
                ViewData[MessageConstants.ErrorMessage] = "Не е намерен такъв ресторант!";
                return RedirectToAction("Index", "Home");
            }

            await this.rService.Activate(restaurant);

            if (restaurant.IsActive)
            {
                ViewData[MessageConstants.SuccessMessage] = "Статуса на ресторанта е успешно променен!";
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeactivateAsync(Guid id)
        {
            var restaurant = await this.rService.GetByIdAsync(id);
            if (restaurant == null)
            {
                ViewData[MessageConstants.ErrorMessage] = "Не е намерен такъв ресторант!";
                return RedirectToAction("Index", "Home");
            }

            await this.rService.Deactivate(restaurant);

            if (!restaurant.IsActive)
            {
                ViewData[MessageConstants.SuccessMessage] = "Статуса на ресторанта е успешно променен!";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
