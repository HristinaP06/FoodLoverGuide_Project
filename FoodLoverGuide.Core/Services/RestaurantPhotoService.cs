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
    public class RestaurantPhotoService : IRestaurantPhotoService
    {
        private readonly IRepository<RestaurantPhoto> _repo;

        public RestaurantPhotoService(IRepository<RestaurantPhoto> repo)
        {
            _repo = repo;
        }
        public async Task Add(RestaurantPhoto entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<RestaurantPhoto>> Find(Expression<Func<RestaurantPhoto, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public IQueryable<RestaurantPhoto> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<RestaurantPhoto> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(RestaurantPhoto entity)
        {
            await _repo.Update(entity);
        }
    }
}
