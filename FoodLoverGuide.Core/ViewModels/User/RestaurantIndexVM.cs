using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.ViewModels.User
{
    public class RestaurantIndexVM
    {
        public List<Models.Restaurant> Restaurants { get; set; }

        public List<Models.Category> Categories { get; set; }

        public List<Models.Feature> Features { get; set; }
    }
}
