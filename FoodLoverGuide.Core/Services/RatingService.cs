using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRepository repo;

        public RatingService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(Rating entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<Rating>(id);
        }

        public async Task<List<Rating>> Find(Expression<Func<Rating, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<Rating> GetAll()
        {
            return this.repo.GetAllAsync<Rating>();
        }

        public async Task<Rating> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<Rating>(id);
        }

        public async Task Update(Rating entity)
        {
            await this.repo.UpdateAsync(entity);
        }
    }
}
