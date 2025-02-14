using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.DataAccess.Repository
{
    public interface IRepository 
    {
        Task AddAsync<T>(T entity) where T : class;

        Task UpdateAsync<T> (T entity) where T : class;

        Task DeleteAsync<T> (Guid id) where T : class;

        Task<T> GetByIdAsync<T>(Guid id) where T : class;

        IQueryable<T> GetAllAsync<T> () where T : class;

        Task<List<T>> FindAsync<T>(Expression<Func<T,bool>> filter) where T : class;
    }
}
