using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.Validators;
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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> Find(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _repo.GetAll();
        }

        public Category GetRestaurantCategory(Guid restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
