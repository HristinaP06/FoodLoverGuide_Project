using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Models
{
    public class RestaurantFeatures
    {
        public Guid FeatureId { get; set; }
        public Features Feature { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
