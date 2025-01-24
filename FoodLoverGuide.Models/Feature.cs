using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Models
{
    public class Feature
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<RestaurantFeature> RestaurantsList { get; set; }

    }
}
