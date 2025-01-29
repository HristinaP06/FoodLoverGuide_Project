using System.ComponentModel.DataAnnotations.Schema;

namespace FoodLoverGuide.Models
{
    public class RestaurantFeature
    {
        [ForeignKey(nameof(Feature))]
        public Guid FeatureId { get; set; }

        public Feature Features { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }

        public Restaurant Restaurants { get; set; }
    }
}
