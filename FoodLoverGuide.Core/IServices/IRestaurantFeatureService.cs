using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
    public interface IRestaurantFeatureService : IService<RestaurantFeature>
    {
        Task<Guid> AddRestaurantFeatures(AddFeatureToRestaurantVM model);

        Task<Guid> UpdateRestaurantFeaturesAsync(AddFeatureToRestaurantVM model);

        Task<List<Guid>> GetFeatureIdsForRestaurantAsync(Guid restaurantId);
    }
}
