using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodLoverGuide.Models
{
    public class WorkTimeSchedule
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public DayOfWeek Date { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

    }
}
