using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repo;

        public ReviewService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(Review entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<Review>(id);
        }

        public async Task<List<Review>> Find(Expression<Func<Review, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<Review> GetAll()
        {
            return this.repo.GetAllAsync<Review>();
        }

        public async Task<Review> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<Review>(id);
        }

        public async Task Update(Review entity)
        {
            await this.repo.UpdateAsync(entity);
        }
    }
}
