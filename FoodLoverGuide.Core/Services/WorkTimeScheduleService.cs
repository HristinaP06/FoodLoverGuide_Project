using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class WorkTimeScheduleService : IWorkTimeScheduleService
    {
        private readonly IRepository repo;

        public WorkTimeScheduleService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(WorkTimeSchedule entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<WorkTimeSchedule>(id);
        }

        public async Task<List<WorkTimeSchedule>> Find(Expression<Func<WorkTimeSchedule, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<WorkTimeSchedule> GetAll()
        {
            return this.repo.GetAllAsync<WorkTimeSchedule>();
        }

        public async Task<WorkTimeSchedule> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<WorkTimeSchedule>(id);
        }

        public async Task Update(WorkTimeSchedule entity)
        {
            await this.repo.UpdateAsync(entity);
        }
    }
}
