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
    public class FeatureService : IFeatureService
    {
        private readonly IRepository<Feature> _repo;

        public FeatureService(IRepository<Feature> repo)
        {
            _repo = repo;
        }

        public async Task Add(Feature entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<Feature>> Find(Expression<Func<Feature, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public IQueryable<Feature> GetAll()
        {
            return  _repo.GetAll();
        }

        public async Task<Feature> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(Feature entity)
        {
            await _repo.Update(entity);
        }
    }
}
