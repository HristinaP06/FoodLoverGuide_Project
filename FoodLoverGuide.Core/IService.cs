
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core
{
    public interface IService<T> where T: class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<List<T>> Find (Expression<Func<T, bool>> filter);

    }
}
