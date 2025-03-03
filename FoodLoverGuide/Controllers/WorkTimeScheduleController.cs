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

            // Get existing schedule for the restaurant
            var workTimeSchedules = this.workTimeScheduleService.GetAll()
                .Where(w => w.RestaurantId == restaurantId)
                .ToList();

            // Initialize a list of schedules, filling in missing days
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
                foreach (var schedule in model.WorkTimeSchedules)
                {
                    var existingSchedule = this.workTimeScheduleService.GetAll()
                        .FirstOrDefault(w => w.RestaurantId == model.RestaurantId && w.Day == schedule.Day);

                    if (existingSchedule == null)
                    {
                        // Add new schedule for this day
                        await this.workTimeScheduleService.Add(new WorkTimeSchedule
                        {
                            RestaurantId = model.RestaurantId,
                            Day = schedule.Day,
                            OpeningTime = schedule.OpeningTime,
                            ClosingTime = schedule.ClosingTime
                        });
                    }
                    else
                    {
                        // Update existing schedule
                        existingSchedule.OpeningTime = schedule.OpeningTime;
                        existingSchedule.ClosingTime = schedule.ClosingTime;
                        await this.workTimeScheduleService.Update(existingSchedule);
                    }
                }

                return RedirectToAction("Index", "Restaurant"); // Redirect to restaurant list or another page
            }

            return View(model); // Return view with validation errors
        }
    }
}
