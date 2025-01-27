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
        void Add (T entity);

        void Update (T entity);

        void Delete (Guid id);

        T Get (Guid id);

        List<T> GetAll ();

        List<T> Find(Expression<Func<T,bool>> filter);

        List<T> CheckIfExists(List<Guid> id);
    }
}
