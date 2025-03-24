using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.UserArea;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodLoverGuide.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly IRestaurantService restaurantService;

        public ReservationController(IReservationService reservationService, IRestaurantService restaurantService)
        {
            this.reservationService = reservationService;
            this.restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid restaurantId, DateTime? selectedDate)
        {
            var availableTimes = new List<DateTime>();

            if (selectedDate.HasValue)
            {
                availableTimes = await reservationService.GetAvailableTimes(restaurantId, selectedDate.Value);
            }

            var model = new ReservationVM
            {
                RestaurantId = restaurantId,
                AvailableTimes = availableTimes,
                SelectedDate = selectedDate ?? DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationVM model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableTimes = await reservationService.GetAvailableTimes(model.RestaurantId, model.SelectedDate);
                return View(model);
            }

            var userId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!await reservationService.IsRestaurantOpen(model.RestaurantId, model.SelectedDate))
            {
                ModelState.AddModelError("", "Ресторантът не е отворен за дадения час.");
            }
            else if (!await reservationService.HasAvailableSeats(model.RestaurantId, model.SelectedDate, model.Adults + model.Children))
            {
                ModelState.AddModelError("", "Няма достатъчно места за избрания час,");
            }
            else if (!await reservationService.IsDuplicateReservation(model.RestaurantId, userId, model.SelectedDate))
            {
                ModelState.AddModelError("", "Вече имате резервация за този час.");
            }

            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                RestaurantId = model.RestaurantId,
                UserId = userId,
                Date = model.SelectedDate,
                Adults = model.Adults,
                Children = model.Children
            };

            await reservationService.Add(reservation);

            return RedirectToAction("Success", new {restaurantId = model.RestaurantId});
        } 

        public IActionResult Success(Guid restaurantId)
        {
            ViewData["RestaurantId"] = restaurantId;
            return View();
        }
    }
}
