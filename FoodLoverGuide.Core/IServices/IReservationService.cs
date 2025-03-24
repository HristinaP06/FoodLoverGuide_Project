using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
    public interface IReservationService : IService<Reservation>
    {
        Task<bool> IsRestaurantOpen(Guid restaurantId, DateTime dateTime);

        Task<bool> HasAvailableSeats(Guid restaurantId, DateTime date, int guests);

        Task<List<DateTime>> GetAvailableTimes(Guid restaurantId, DateTime date);

        Task<bool> IsDuplicateReservation(Guid restaurantId, string userId, DateTime dateTime);
    }
}
