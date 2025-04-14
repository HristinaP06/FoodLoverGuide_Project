using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.IServices
{
    public interface IRestaurantService
    {
        Task<Guid> AddRestaurantAsync(RestaurantCreateVM model);

        Task DeleteRestaurantAsync(Guid id);

        Task<List<Restaurant>> Find(Expression<Func<Restaurant, bool>> filter);

        IQueryable<Restaurant> GetAllRestaurants(string restaurantName = null, bool? isActive = null);

        IQueryable<Restaurant> GetRestaurantsWithFilters(string[] categoryIds = null, string[] featureIds = null, string priceRange = null, string rating = null);

        Task<Restaurant> GetByIdAsync(Guid id);

        Task<Restaurant> GetByIdWithIncludesAsync(Guid id);

        Task UpdateAsync(RestaurantCreateVM entity);

        Task ActivateAsync(Restaurant restaurant);

        Task DeactivateAsync(Restaurant restaurant);
    }
}
