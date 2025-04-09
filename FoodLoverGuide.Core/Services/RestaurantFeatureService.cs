using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class RestaurantFeatureService : IRestaurantFeatureService
    {
        private readonly IRepository repo;

        public RestaurantFeatureService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(RestaurantFeature entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<RestaurantFeature>(id);
        }

        public async Task<List<RestaurantFeature>> Find(Expression<Func<RestaurantFeature, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<RestaurantFeature> GetAll()
        {
            return this.repo.GetAllAsync<RestaurantFeature>();
        }

        public async Task<RestaurantFeature> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<RestaurantFeature>(id);
        }

        public async Task Update(RestaurantFeature entity)
        {
            await this.repo.UpdateAsync(entity);
        }

        public async Task<Guid> AddRestaurantFeatures(AddFeatureToRestaurantVM model)
        {
            var addedRestaurantFeatures = this.repo.GetAllAsync<RestaurantFeature>().Select(r => r.FeatureId);

            foreach (var feat in model.SelectedFeaturesIds.Where(r => !addedRestaurantFeatures.Contains(r)))
            {
                var restFeat = new RestaurantFeature()
                {
                    FeatureId = feat,
                    RestaurantId = model.RestaurantId
                };

                await this.repo.AddAsync(restFeat);
            }
            return model.RestaurantId;
        }

        public async Task<List<Guid>> GetFeatureIdsForRestaurantAsync(Guid restaurantId)
        {
            return await this.repo.GetAllAsync<RestaurantFeature>().Where(r => r.RestaurantId == restaurantId).Select(r => r.FeatureId).ToListAsync();
        }
    }
}
