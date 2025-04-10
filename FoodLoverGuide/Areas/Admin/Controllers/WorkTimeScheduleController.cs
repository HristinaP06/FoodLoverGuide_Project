using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Areas.Admin.Controllers
{
    public class WorkTimeScheduleController : BaseController
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
            var restaurant = await restaurantService.GetByIdAsync(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            var workTimeSchedules = workTimeScheduleService.GetAll()
                .Where(w => w.RestaurantId == restaurantId)
                .ToList();

            var weeklySchedule = Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>()
                .OrderBy(d => (d == DayOfWeek.Sunday) ? 7 : (int)d)
                .Select(day => new WorkTimeScheduleViewModel
                {
                    RestaurantId = restaurantId,
                    IsClosed = false,
                    Day = day,
                    OpeningTime = workTimeSchedules.FirstOrDefault(w => w.Day == day)?.OpeningTime ?? TimeSpan.Zero,
                    ClosingTime = workTimeSchedules.FirstOrDefault(w => w.Day == day)?.ClosingTime ?? TimeSpan.Zero
                }).ToList();

            var model = new WeeklyWorkTimeVM
            {
                RestaurantId = restaurantId,
                WorkTimeSchedules = weeklySchedule
            };

            return View("ManageWorkTimeSchedule", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(WeeklyWorkTimeVM model)
        {
            if (ModelState.IsValid)
            {
                Guid id = await workTimeScheduleService.AddWorkTimeToRestaurant(model);

                return RedirectToAction("Create", "RestaurantPhoto", new { restaurantId = id });
            }

            return View("ManageWorkTimeSchedule", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid restaurantId, string nextAction = null)
        {
            var restaurant = await restaurantService.GetByIdAsync(restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }

            var workTimeSchedules = workTimeScheduleService.GetAll()
                .Where(w => w.RestaurantId == restaurantId)
                .ToList();

            var weeklySchedule = Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>()
                .OrderBy(d => (d == DayOfWeek.Sunday) ? 7 : (int)d)
                .Select(day =>
                {
                    var existing = workTimeSchedules.FirstOrDefault(w => w.Day == day);
                    return new WorkTimeScheduleViewModel
                    {
                        RestaurantId = restaurantId,
                        Day = day,
                        IsClosed = existing?.IsClosed ?? false,
                        OpeningTime = existing?.OpeningTime ?? TimeSpan.Zero,
                        ClosingTime = existing?.ClosingTime ?? TimeSpan.Zero
                    };
                }).ToList();

            var model = new WeeklyWorkTimeVM
            {
                RestaurantId = restaurantId,
                WorkTimeSchedules = weeklySchedule,
                NextAction = nextAction
            };

            return View("ManageWorkTimeSchedule", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(WeeklyWorkTimeVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("ManageWorkTimeSchedule", model);
            }

            Guid id = await workTimeScheduleService.UpdateWorkTimeForRestaurantAsync(model);

            if (!string.IsNullOrEmpty(model.NextAction))
            {
                return RedirectToAction(model.NextAction, "RestaurantPhoto", new { restaurantId = id });
            }

            return RedirectToAction("Index", "Restaurant");
        }
    }
}
