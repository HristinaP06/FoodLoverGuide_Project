using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.IServices
{
    public interface IRestaurantService
    {
        Task AddRestaurant(RestaurantDetailsVM model);

        Task DeleteRestaurant(Guid id);

        Task<List<Restaurant>> Find(Expression<Func<Restaurant, bool>> filter);

        IQueryable<Restaurant> GetAllRestaurants();

        Task<Restaurant> GetById(Guid id);

        Task Update(RestaurantDetailsVM entity);
    }
}
