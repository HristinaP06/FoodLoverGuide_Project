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
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _repo;

        public ContactService(IRepository<Contact> repo)
        {
            _repo = repo;
        }

        public async Task Add(Contact entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<Contact>> Find(Expression<Func<Contact, bool>> filter)
        {
            return await _repo.Find(filter);
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Contact> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(Contact entity)
        {
            await _repo.Update(entity);
        }
    }
}
