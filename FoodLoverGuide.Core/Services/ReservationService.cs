using FoodLoverGuide.Core.IServices;
using FoodLoverGuide.DataAccess.Repository;
using FoodLoverGuide.Models;
using System.Linq.Expressions;

namespace FoodLoverGuide.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository repo;

        public ReservationService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task Add(Reservation entity)
        {
            await this.repo.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            await this.repo.DeleteAsync<Reservation>(id);
        }

        public async Task<List<Reservation>> Find(Expression<Func<Reservation, bool>> filter)
        {
            return await this.repo.FindAsync(filter);
        }

        public IQueryable<Reservation> GetAll()
        {
            return this.repo.GetAllAsync<Reservation>();
        }

        public async Task<Reservation> GetById(Guid id)
        {
            return await this.repo.GetByIdAsync<Reservation>(id);
        }

        public async Task Update(Reservation entity)
        {
            await this.repo.UpdateAsync(entity);
        }
    }
}
