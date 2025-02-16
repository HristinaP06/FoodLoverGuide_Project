using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class RestaurantPhotoService : IRestaurantPhotoService
    {
        private readonly IRepository repo;

        public RestaurantPhotoService(IRepository repo)
        {
            this.repo = repo;
        }
        public async Task Add(RestaurantPhoto entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<RestaurantPhoto>(id);
        }

        public async Task<List<RestaurantPhoto>> Find(Expression<Func<RestaurantPhoto, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<RestaurantPhoto> GetAll()
        {
            return this.repo.GetAllAsync<RestaurantPhoto>();
        }

        public async Task<RestaurantPhoto> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<RestaurantPhoto>(id);
        }

        public async Task Update(RestaurantPhoto entity)
        {
            await this.repo.UpdateAsync(entity);
        }
    }
}
