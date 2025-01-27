using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
