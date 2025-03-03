using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class WorkTimeScheduleViewModel
    {
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public DayOfWeek Day { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan OpeningTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan ClosingTime { get; set; }
    }
}
