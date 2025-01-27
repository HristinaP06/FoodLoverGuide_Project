using System.ComponentModel.DataAnnotations.Schema;

namespace FoodLoverGuide.Models
{
    public class RestaurantCategories
    {
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
