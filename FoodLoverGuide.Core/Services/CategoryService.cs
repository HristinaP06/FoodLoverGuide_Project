using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repo;

        public CategoryService(IRepository<Category> repo)
        {
            _repo = repo;
        }

        public async Task Add(Category entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
             await _repo.Delete(id);
        }

        public async Task<List<Category>> Find(Expression<Func<Category, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public IQueryable<Category> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public Category GetRestaurantCategory(Guid restaurantId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Category entity)
        {
             await _repo.Update(entity);
        }
    }
}
