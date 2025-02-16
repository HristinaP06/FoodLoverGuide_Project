using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly IRepository repo;

        public FeatureService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(Feature entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<Feature>(id);
        }

        public async Task<List<Feature>> Find(Expression<Func<Feature, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<Feature> GetAll()
        {
            return  this.repo.GetAllAsync<Feature>();
        }

        public async Task<Feature> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<Feature>(id);
        }

        public async Task Update(Feature entity)
        {
            await this.repo.UpdateAsync(entity);
        }
    }
}
