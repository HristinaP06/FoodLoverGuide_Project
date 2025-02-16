using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IRepository repo;

        public MenuItemService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(MenuItem entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<MenuItem>(id);
        }

        public async Task<List<MenuItem>> Find(Expression<Func<MenuItem, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<MenuItem> GetAll()
        {
            return this.repo.GetAllAsync<MenuItem>();
        }

        public async Task<MenuItem> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<MenuItem>(id);
        }

        public async Task Update(MenuItem entity)
        {
            await this.repo.UpdateAsync(entity);
        }
    }
}
