using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
    public interface IWorkTimeScheduleService : IService<WorkTimeSchedule>
    {
        Task<Guid> AddWorkTimeToRestaurant(WeeklyWorkTimeVM vm);

        Task<Guid> UpdateWorkTimeForRestaurantAsync(WeeklyWorkTimeVM model);
    }
}
