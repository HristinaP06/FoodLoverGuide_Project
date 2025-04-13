using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.ViewModels.UserArea
{
    public class HomeVM
    {
        public List<FoodLoverGuide.Models.Restaurant> Restaurants { get; set; }

        public int RestaurantsCount { get; set; }

        public List<Review> LatestReviews { get; set; }

        public List<FoodLoverGuide.Models.RestaurantPhoto> FeaturedPhotos { get; set; }
    }
}
