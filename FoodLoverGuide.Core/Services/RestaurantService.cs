using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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

        public IQueryable<Restaurant> GetRestaurantsWithFilters(
            string[] categoryIds = null,
            string[] featureIds = null,
            string priceRange = null,
            string rating = null)
        {
            IQueryable<Restaurant> restaurants = this.repo.GetAllAsync<Restaurant>()
                .Include(c => c.RestaurantCategoriesList)
                .ThenInclude(y => y.Category)
                .Include(f => f.Features)
                .ThenInclude(x => x.Features)
                .Include(r => r.Reviews)
                .Include(p => p.Photos);

            if (categoryIds != null && categoryIds.Any())
            {
                restaurants = restaurants.Where(r => r.RestaurantCategoriesList
                    .Any(rc => categoryIds.Contains(rc.CategoryId.ToString())));
            }

            if (featureIds != null && featureIds.Any())
            {
                restaurants = restaurants.Where(r => r.Features
                    .Any(f => featureIds.Contains(f.FeatureId.ToString())));
            }

            // Filter by price range
            if (!string.IsNullOrEmpty(priceRange))
            {
                switch (priceRange.ToLower())
                {
                    case "budget":
                        restaurants = restaurants.Where(r => r.PriceRangeTo <= 18);
                        break;
                    case "middle":
                        restaurants = restaurants.Where(r => r.PriceRangeFrom >= 18 && r.PriceRangeTo <= 45);
                        break;
                    case "premium":
                        restaurants = restaurants.Where(r => r.PriceRangeTo > 45);
                        break;
                }
            }

            // Filter by rating
            if (!string.IsNullOrEmpty(rating) && double.TryParse(rating, NumberStyles.Any, CultureInfo.InvariantCulture, out double minRating))
            {
                restaurants = restaurants.Where(r => r.Reviews.Any()
                    ? r.Reviews.Average(rev => rev.Rating) >= minRating
                    : false);
            }

            return restaurants;
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

        public async Task Activate(Restaurant restaurant)
        {
            if (restaurant.IsActive)
            {
                return;
            }
            
            restaurant.IsActive = true;
            await this.repo.UpdateAsync(restaurant);
        }

        public async Task Deactivate(Restaurant restaurant)
        {
            if (!restaurant.IsActive)
            {
                return;
            }
            restaurant.IsActive = false;
            await this.repo.UpdateAsync(restaurant);
        }
    }
}
