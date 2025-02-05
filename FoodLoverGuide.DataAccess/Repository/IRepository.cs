using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.DataAccess.Repository
{
    public interface IRepository <T> where T : class
    {
        Task Add (T entity);

        Task Update (T entity);

        Task Delete (Guid id);

        Task<T> GetById(Guid id);

        IQueryable<T> GetAll ();

        Task<List<T>> Find(Expression<Func<T,bool>> filter);
    }
}
