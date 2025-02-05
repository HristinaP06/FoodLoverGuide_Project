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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IRepository<SocialMedia> _repo;

        public SocialMediaService(IRepository<SocialMedia> repo)
        {
            _repo = repo;
        }

        public async Task Add(SocialMedia entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<SocialMedia>> Find(Expression<Func<SocialMedia, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public IQueryable<SocialMedia> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<SocialMedia> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(SocialMedia entity)
        {
            await _repo.Update(entity);
        }
    }
}
