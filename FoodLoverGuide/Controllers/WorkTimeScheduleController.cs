using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FoodLoverGuide.Controllers
{
    public class WorkTimeScheduleController : Controller
    {
        private readonly IWorkTimeScheduleService workTimeScheduleService;
        private readonly IRestaurantService restaurantService;

        public WorkTimeScheduleController(
            IWorkTimeScheduleService workTimeScheduleService, IRestaurantService restaurantService)
        {
            this.workTimeScheduleService = workTimeScheduleService;
            this.restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid restaurantId)
        {
            var restaurant = await this.restaurantService.GetByIdAsync(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            var workTimeSchedules = this.workTimeScheduleService.GetAll()
                .Where(w => w.RestaurantId == restaurantId)
                .ToList();

            var weeklySchedule = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
                .Select(day => new WorkTimeScheduleViewModel
                {
                    RestaurantId = restaurantId,
                    Day = day,
                    OpeningTime = workTimeSchedules.FirstOrDefault(w => w.Day == day)?.OpeningTime ?? TimeSpan.Zero,
                    ClosingTime = workTimeSchedules.FirstOrDefault(w => w.Day == day)?.ClosingTime ?? TimeSpan.Zero
                }).ToList();

            var model = new WeeklyWorkTimeVM
            {
                RestaurantId = restaurantId,
                WorkTimeSchedules = weeklySchedule
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(WeeklyWorkTimeVM model)
        {
            var json = JsonSerializer.Serialize(model);

            if (ModelState.IsValid)
            {
                Guid id = await this.workTimeScheduleService.AddWorkTimeToRestaurant(model);
               
                return RedirectToAction("Create", "RestaurantPhoto", new {restaurantId = id}); 
            }

            return View(model);
        }


    }
}
