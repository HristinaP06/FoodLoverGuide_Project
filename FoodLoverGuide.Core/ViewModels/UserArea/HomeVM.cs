using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.ViewModels.UserArea
{
    public class HomeVM
    {
        public List<Models.Restaurant> Restaurants { get; set; }

        public int RestaurantsCount { get; set; }

    }
}
