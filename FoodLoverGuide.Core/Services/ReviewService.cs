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
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repo;

        public ReviewService(IRepository<Review> repo)
        {
            _repo = repo;
        }

        public async Task Add(Review entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<Review>> Find(Expression<Func<Review, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public async Task<List<Review>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Review> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(Review entity)
        {
            await _repo.Update(entity);
        }
    }
}
