using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
