namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class WeeklyWorkTimeVM
    {
        public Guid RestaurantId { get; set; }

        public List<WorkTimeScheduleViewModel> WorkTimeSchedules { get; set; }

        public string NextAction { get; set; }
    }
}
