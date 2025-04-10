using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.IServices
{
    public interface IRestaurantService
    {
        Task<Guid> AddRestaurant(RestaurantCreateVM model);

        Task DeleteRestaurant(Guid id);

        Task<List<Restaurant>> Find(Expression<Func<Restaurant, bool>> filter);

        IQueryable<Restaurant> GetAllRestaurants();

        IQueryable<Restaurant> GetRestaurantsWithFilters(string[] categoryIds = null, string[] featureIds = null, string priceRange = null, string rating = null);

        Task<Restaurant> GetByIdAsync(Guid id);

        Task Update(RestaurantCreateVM entity);

        Task Activate(Restaurant restaurant);

        Task Deactivate(Restaurant restaurant);
    }
}
