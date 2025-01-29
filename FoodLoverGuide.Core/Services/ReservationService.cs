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
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _repo;

        public ReservationService(IRepository<Reservation> repo)
        {
            _repo = repo;
        }

        public async Task Add(Reservation entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<Reservation>> Find(Expression<Func<Reservation, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public async Task<List<Reservation>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Reservation> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(Reservation entity)
        {
            await _repo.Update(entity);
        }
    }
}
