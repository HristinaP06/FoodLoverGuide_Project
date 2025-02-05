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
    public class WorkTimeScheduleService : IWorkTimeScheduleService
    {
        private readonly IRepository<WorkTimeSchedule> _repo;

        public WorkTimeScheduleService(IRepository<WorkTimeSchedule> repo)
        {
            _repo = repo;
        }

        public async Task Add(WorkTimeSchedule entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<WorkTimeSchedule>> Find(Expression<Func<WorkTimeSchedule, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public IQueryable<WorkTimeSchedule> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<WorkTimeSchedule> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(WorkTimeSchedule entity)
        {
            await _repo.Update(entity);
        }
    }
}
