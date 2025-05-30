﻿using FoodLoverGuide.Core.IServices;
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

        public async Task<Guid> AddWorkTimeToRestaurant(WeeklyWorkTimeVM model)
        {
            foreach (var wt in model.WorkTimeSchedules)
            {
                var workTimeSchedule = new WorkTimeSchedule()
                {
                    RestaurantId = model.RestaurantId,
                    Day = wt.Day,
                    IsClosed = wt.IsClosed,
                    OpeningTime = wt.OpeningTime,
                    ClosingTime = wt.ClosingTime
                };

                await this.repo.AddAsync(workTimeSchedule);
            }
            return model.RestaurantId;
        }

        public async Task<Guid> UpdateWorkTimeForRestaurantAsync(WeeklyWorkTimeVM model)
        {
            var existing = this.GetAll()
                .Where(w => w.RestaurantId == model.RestaurantId)
                .ToList();

            foreach (var e in existing)
            {
                await this.repo.DeleteAsync(e);
            }

            foreach (var day in model.WorkTimeSchedules)
            {
                var workTime = new WorkTimeSchedule
                {
                    RestaurantId = model.RestaurantId,
                    Day = day.Day,
                    IsClosed = day.IsClosed,
                    OpeningTime = day.OpeningTime,
                    ClosingTime = day.ClosingTime
                };

                await this.repo.AddAsync(workTime);
            }

            return model.RestaurantId;
        }
    }
}
