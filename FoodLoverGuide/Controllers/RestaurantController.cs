using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodLoverGuide.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _rService;

        public RestaurantController(IRestaurantService rService)
        {
            _rService = rService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var rest = await _rService.GetAllRestaurants().Include(x => x.Features).Include(x => x.RestaurantCategoriesList).ToListAsync();
            var model = rest.Select(r => new RestaurantDetailsVM
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Location = r.Location,
                PriceRangeFrom = r.PriceRangeFrom,
                PriceRangeTo = r.PriceRangeTo,
                IndoorCapacity = r.IndoorCapacity,
                OutdoorCapacity = r.OutdoorCapacity,
                Telephone = r.Telephone,
                Email = r.Email,
                Instagram = r.Instagram,
                Facebook = r.Facebook,
                WebSite = r.WebSite
            });
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(RestaurantDetailsVM model)
        {
            await _rService.AddRestaurant(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var obj = await _rService.GetById(id);
            var vm = new RestaurantDetailsVM
            {
                Name = obj.Name,
                Description = obj.Description,
                Location = obj.Location,
                PriceRangeFrom = obj.PriceRangeFrom,
                PriceRangeTo = obj.PriceRangeTo,
                IndoorCapacity = obj.IndoorCapacity,
                OutdoorCapacity = obj.OutdoorCapacity,
                Telephone = obj.Telephone,
                Email = obj.Email,
                Instagram = obj.Instagram,
                Facebook = obj.Facebook,
                WebSite = obj.WebSite
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(RestaurantDetailsVM model)
        {
            await _rService.Update(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _rService.DeleteRestaurant(id);

            return RedirectToAction("Index");
        }
    }
}
