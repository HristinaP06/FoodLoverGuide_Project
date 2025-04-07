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

            // Проверки с правилна логика
            if (!await reservationService.IsRestaurantOpen(model.RestaurantId, model.SelectedDate))
            {
                ModelState.AddModelError("", "Ресторантът не е отворен за дадения час.");
            }

            if (!await reservationService.HasAvailableSeats(model.RestaurantId, model.SelectedDate, model.Adults + model.Children))
            {
                ModelState.AddModelError("", "Няма достатъчно места за избрания час.");
            }

            if (await reservationService.IsDuplicateReservation(model.RestaurantId, userId, model.SelectedDate))
            {
                ModelState.AddModelError("", "Вече имате резервация за този час.");
            }

            // Ако има грешки, връщаме изгледа
            if (!ModelState.IsValid)
            {
                model.AvailableTimes = await reservationService.GetAvailableTimes(model.RestaurantId, model.SelectedDate);
                return View(model);
            }

            // Създаване на резервацията само ако няма грешки
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

            return RedirectToAction("Success", new { restaurantId = model.RestaurantId });
        }

        public IActionResult Success(Guid restaurantId)
        {
            ViewData["RestaurantId"] = restaurantId;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid reservationId, Guid restaurantId, DateTime? selectedDate)
        {
            var reservation = await reservationService.GetById(reservationId);
            if (reservation == null)
            {
                return NotFound();
            }

            var dateToUse = selectedDate ?? reservation.Date;
            var availableTimes = await reservationService.GetAvailableTimes(restaurantId, dateToUse);

            var model = new ReservationVM
            {
                RestaurantId = restaurantId,
                SelectedDate = dateToUse,
                Adults = reservation.Adults ?? 1,
                Children = reservation.Children ?? 0,
                AvailableTimes = availableTimes
            };

            ViewBag.ReservationId = reservationId; 
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReservationVM model, Guid reservationId)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableTimes = await reservationService.GetAvailableTimes(model.RestaurantId, model.SelectedDate);
                ViewBag.ReservationId = reservationId;
                return View(model);
            }

            var userId = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            var existingReservation = await reservationService.GetById(reservationId);

            if (existingReservation == null)
            {
                return NotFound();
            }

            // Проверки
            if (!await reservationService.IsRestaurantOpen(model.RestaurantId, model.SelectedDate))
            {
                ModelState.AddModelError("", "Ресторантът не е отворен за дадения час.");
            }

            if (!await reservationService.HasAvailableSeats(model.RestaurantId, model.SelectedDate, model.Adults + model.Children))
            {
                ModelState.AddModelError("", "Няма достатъчно места за избрания час.");
            }

            if (await reservationService.IsDuplicateReservation(model.RestaurantId, userId, model.SelectedDate) &&
                existingReservation.Date != model.SelectedDate) 
            {
                ModelState.AddModelError("", "Вече имате резервация за този час.");
            }

            if (!ModelState.IsValid)
            {
                model.AvailableTimes = await reservationService.GetAvailableTimes(model.RestaurantId, model.SelectedDate);
                ViewBag.ReservationId = reservationId;
                return View(model);
            }

            // Актуализиране на резервацията
            existingReservation.Date = model.SelectedDate;
            existingReservation.Adults = model.Adults;
            existingReservation.Children = model.Children;

            await reservationService.Update(existingReservation);

            return RedirectToAction("Success", new { restaurantId = model.RestaurantId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid reservationId)
        {
            var reservation = await reservationService.GetById(reservationId);
            var userId = reservation.UserId;
            if (reservation == null)
            {
                return NotFound();
            }

            await reservationService.Delete(reservationId);
            return RedirectToAction("Index", "User",new { id = userId}); // Пренасочване към профила след изтриване
        }
    }
}
