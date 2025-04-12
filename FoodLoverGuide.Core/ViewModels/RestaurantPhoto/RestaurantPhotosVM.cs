namespace FoodLoverGuide.Core.ViewModels.RestaurantPhoto
{
    public class RestaurantPhotosVM
    {
        public Guid RestaurantId { get; set; }

        public IList<FoodLoverGuide.Models.RestaurantPhoto> RestaurantPhotos { get; set; }
    }
}
