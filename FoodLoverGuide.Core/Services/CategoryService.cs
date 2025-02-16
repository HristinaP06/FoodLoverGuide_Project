using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        public CategoryService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(Category entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
             await this.repo.DeleteAsync<Category>(id);
        }

        public async Task<List<Category>> Find(Expression<Func<Category, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<Category> GetAll()
        {
            return this.repo.GetAllAsync<Category>();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<Category>(id);
        }

        public Category GetRestaurantCategory(Guid restaurantId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Category entity)
        {
             await this.repo.UpdateAsync(entity);
        }
    }
}
