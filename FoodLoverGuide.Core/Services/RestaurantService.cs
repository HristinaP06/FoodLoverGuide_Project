using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository repo;
        private readonly IRestaurantCategoriesService restaurantCategoriesService;

        public RestaurantService(IRepository repo, IRestaurantCategoriesService restaurantCategoriesService)
        {
            this.repo = repo;
            this.restaurantCategoriesService = restaurantCategoriesService;
        }

        public async Task<Guid> AddRestaurant(RestaurantCreateVM model)
        {
            var restaurant = new Restaurant()
            {
                Id = new Guid(),
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                PriceRangeFrom = model.PriceRangeFrom,
                PriceRangeTo = model.PriceRangeTo,
                IndoorCapacity = model.IndoorCapacity,
                OutdoorCapacity = model.OutdoorCapacity,
                Telephone = model.Telephone,
                Email = model.Email,
                Instagram = model.Instagram,
                Facebook = model.Facebook,
                WebSite = model.WebSite
            };

            await this.repo.AddAsync(restaurant);

            return restaurant.Id;
        }

        public async Task DeleteRestaurant(Guid id)
        {
            await this.repo.DeleteAsync<Restaurant>(id);
        }

        public async Task<List<Restaurant>> Find(Expression<Func<Restaurant, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<Restaurant> GetAllRestaurants()
        {
            return this.repo.GetAllAsync<Restaurant>();
        }

        public async Task<Restaurant> GetByIdAsync(Guid id)
        {
            return await this.repo.GetByIdAsync<Restaurant>(id);
        }

        public async Task Update(RestaurantCreateVM model)
        {
            var restaurant = new Restaurant()
            {
                Id = model.Id.Value,
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                PriceRangeFrom = model.PriceRangeFrom,
                PriceRangeTo = model.PriceRangeTo,
                IndoorCapacity = model.IndoorCapacity,
                OutdoorCapacity = model.OutdoorCapacity,
                Telephone = model.Telephone,
                Email = model.Email,
                Instagram = model.Instagram,
                Facebook = model.Facebook,
                WebSite = model.WebSite
            };

            await this.repo.UpdateAsync(restaurant);
        }
    }
}
