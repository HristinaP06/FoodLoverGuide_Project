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
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _repo;

        public RatingService(IRepository<Rating> repo)
        {
            _repo = repo;
        }

        public async Task Add(Rating entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<Rating>> Find(Expression<Func<Rating, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public IQueryable<Rating> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<Rating> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(Rating entity)
        {
            await _repo.Update(entity);
        }
    }
}
