using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Models
{
    public class WorkTimeSchedule
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public DayOfWeek Day { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }
    }
}
