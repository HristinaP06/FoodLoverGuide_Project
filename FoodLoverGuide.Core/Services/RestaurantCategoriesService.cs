using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.Services
{
    public class RestaurantCategoriesService : IRestaurantCategoriesService
    {
        private readonly IRepository<RestaurantCategories> _repo;

        public RestaurantCategoriesService(IRepository<RestaurantCategories> repo)
        {
            _repo = repo;
        }

        public async Task Add(RestaurantCategories entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<RestaurantCategories>> Find(Expression<Func<RestaurantCategories, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public IQueryable<RestaurantCategories> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<RestaurantCategories> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(RestaurantCategories entity)
        {
            await _repo.Update(entity);
        }
    }
}
