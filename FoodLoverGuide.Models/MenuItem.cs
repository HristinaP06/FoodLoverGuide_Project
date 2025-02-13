using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Models
{
    public class MenuItem
    {
        [Key]
        public Guid Id { get; set; }

        public string? Photo { get; set; }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
