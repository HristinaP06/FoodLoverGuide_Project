using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Models
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; }

        public double _Rating { get; set; }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
