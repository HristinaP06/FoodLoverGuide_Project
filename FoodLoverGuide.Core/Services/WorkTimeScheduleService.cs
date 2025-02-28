using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.VisualBasic;
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

        public async Task<Guid> AddWorkTimeToRestaurant(AddWorkTimeScheduleToRestaurantVM model)
        {
            foreach (var wt in model.WorkSchedule)
            {
                var workTimeSchedule = new WorkTimeSchedule()
                {
                    RestaurantId = model.RestaurantId,
                    Day = wt.Key,
                    OpeningTime = wt.Value.FirstOrDefault(),
                    ClosingTime = wt.Value.Last()
                };

                await this.repo.AddAsync(workTimeSchedule);
            }
            return model.RestaurantId;
        }
    }
}
