using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }
        public async Task Add(User entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<User>(id);
        }

        public async Task<List<User>> Find(Expression<Func<User, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<User> GetAll()
        {
            return  this.repo.GetAllAsync<User>();
        }

        public async Task<User> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<User>(id);
        }

        public async Task Update(User entity)
        {
            await this.repo.UpdateAsync(entity);
        }
    }
}
