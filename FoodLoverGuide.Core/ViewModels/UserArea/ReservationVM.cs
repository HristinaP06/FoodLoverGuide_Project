using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Core.ViewModels.UserArea
{
    public class ReservationVM
    {
        public Guid RestaurantId { get; set; }

        [Required]
        public DateTime SelectedDate { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public List<DateTime> AvailableTimes { get; set; } = new List<DateTime>();
    }
}
