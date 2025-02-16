using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodLoverGuide.DataAccess.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;
        
        public DbSet<T> DbSet<T>() where T : class
        {
            return this.context.Set<T>();
        }

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(Guid id) where T : class
        {
            var entity = await DbSet<T>().FindAsync(id);
            if (entity == null) 
            {
                throw new ArgumentException("id is null");
            }
            DbSet<T>().Remove(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            DbSet<T>().Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<T>> FindAsync<T>(Expression<Func<T, bool>> filter) where T : class
        {
            return await DbSet<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(Guid id) where T : class
        {
            var entity = await DbSet<T>().FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("id is null");
            }
            return entity;
        }

        public IQueryable<T> GetAllAsync<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }
    }
}
