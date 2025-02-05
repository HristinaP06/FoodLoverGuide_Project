using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Models
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? RestaurantId { get; set; }

        public Restaurant? Restaurant { get; set; }

        public int? Adults { get; set; }

        public int? Children { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
