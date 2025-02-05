﻿using FoodLoverGuide.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core
{
    public class Service<T> : IService<T> where T : class
    {

        private readonly IRepository<T> _repo;
        public async Task Add(T entity)
        {
            await _repo.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repo.Delete(id);
        }

        public async Task<List<T>> Find(Expression<Func<T, bool>> filter)
        {
           return await _repo.Find(filter);
        }

        public IQueryable<T> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task Update(T entity)
        {
            await _repo.Update(entity);
        }
        
        public async Task<T> GetById(Guid Id)
        {
            return await _repo.GetById(Id);
        }
    }
}
