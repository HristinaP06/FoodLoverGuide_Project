using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository repo;
        private readonly IWorkTimeScheduleService workTimeScheduleService;
        private readonly IRestaurantService restaurantService;

        public ReservationService(IRepository repo, 
            IWorkTimeScheduleService workTimeScheduleService, 
            IRestaurantService restaurantService)
        {
            this.repo = repo;
            this.workTimeScheduleService = workTimeScheduleService;
            this.restaurantService = restaurantService;
        }

        public async Task Add(Reservation entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<Reservation>(id);
        }

        public async Task<List<Reservation>> Find(Expression<Func<Reservation, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<Reservation> GetAll()
        {
            return this.repo.GetAllAsync<Reservation>();
        }

        public async Task<Reservation> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<Reservation>(id);
        }

        public async Task Update(Reservation entity)
        {
            await this.repo.UpdateAsync(entity);
        }

        public async Task<bool> IsRestaurantOpen(Guid restaurantId, DateTime dateTime)
        {
            var workSchedule = await workTimeScheduleService.Find(w => w.RestaurantId == restaurantId && w.Day == dateTime.DayOfWeek);
            var schedule = workSchedule.FirstOrDefault();

            if (schedule == null || schedule.IsClosed)
            {
                return false;
            }

            var rawClosingTime = schedule.ClosingTime == TimeSpan.Zero
                ? TimeSpan.FromHours(24)
                : schedule.ClosingTime;
            var reservationLimit = rawClosingTime - TimeSpan.FromHours(2);
            return dateTime.TimeOfDay >= schedule.OpeningTime && dateTime.TimeOfDay <= reservationLimit;
        }

        public async Task<bool> HasAvailableSeats(Guid restaurantId, DateTime date, int guests)
        {
            var restaurant = await restaurantService.GetByIdAsync(restaurantId);

            if (restaurant == null)
            {
                return false;
            }

            var totalCapacity = restaurant.IndoorCapacity + restaurant.OutdoorCapacity;

            var existingReservations = await repo.FindAsync<Reservation>(r => r.RestaurantId == restaurantId && r.Date == date);
            int occupiedSeats = existingReservations.Sum(r => (r.Adults ?? 0) + (r.Children ?? 0));

            return (occupiedSeats + guests) <= totalCapacity;
        }

        public async Task<bool> IsDuplicateReservation(Guid restaurantId, string userId, DateTime dateTime)
        {
            var existingReservation = await repo.FindAsync<Reservation>(r =>
            r.RestaurantId == restaurantId && r.UserId == userId && r.Date == dateTime);

            return existingReservation.Any();
        }

        public async Task<List<DateTime>> GetAvailableTimes(Guid restaurantId, DateTime date)
        {
            var schedule = await workTimeScheduleService.Find(w => w.RestaurantId == restaurantId && w.Day == date.DayOfWeek);
            var workTime = schedule.FirstOrDefault();

            if (workTime == null || workTime.IsClosed)
            {
                return new List<DateTime>();
            }

            var availableTimes = new List<DateTime>();
            var startTime = date.Date + workTime.OpeningTime;
            var rawClosingTime = workTime.ClosingTime == TimeSpan.Zero
                ? TimeSpan.FromHours(24)
                : workTime.ClosingTime;
            var endTime = date.Date + rawClosingTime - TimeSpan.FromHours(2);

            var currentTime = startTime;
            while (currentTime <= endTime)
            {
                availableTimes.Add(currentTime);
                currentTime = currentTime.AddMinutes(60);
            }

            return availableTimes;
        }


    }
}
