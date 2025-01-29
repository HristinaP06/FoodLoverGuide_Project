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
    public class MenuItemService : IMenuItemService
    {
        private readonly IRepository<MenuItem> _repo;

        public MenuItemService(IRepository<MenuItem> repo)
        {
            _repo = repo;
        }

        public async Task Add(MenuItem entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<MenuItem>> Find(Expression<Func<MenuItem, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public async Task<List<MenuItem>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<MenuItem> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(MenuItem entity)
        {
            await _repo.Update(entity);
        }
    }
}
