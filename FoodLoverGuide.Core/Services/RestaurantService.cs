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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _repo;

        public RestaurantService(IRepository<Restaurant> repo)
        {
            _repo = repo;
        }

        public async Task Add(Restaurant entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<Restaurant>> Find(Expression<Func<Restaurant, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public async Task<List<Restaurant>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Restaurant> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(Restaurant entity)
        {
            await _repo.Update(entity);
        }
    }
}
