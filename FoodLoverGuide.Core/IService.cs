using System.Linq.Expressions;

namespace FoodLoverGuide.Core
{
    public interface IService<T> where T: class
    {
        Task Add(T entity);

        Task Update(T entity);

        Task Delete(Guid id);

        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task<List<T>> Find(Expression<Func<T, bool>> filter);
    }
}
