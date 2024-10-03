using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Models.Base;
using MovieTicket.Web.Data;

namespace MovieTicket.Web.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            EntityEntry toAdd = await _context.Set<T>().AddAsync(entity);
            toAdd.State = EntityState.Added;

            return toAdd != null;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            EntityEntry toDelete = _context.Set<T>().Remove(entity);

            toDelete.State = EntityState.Deleted;

            return toDelete != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var entities = await _context.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, 
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> entity = _context.Set<T>();

            if(includeProperties != null)
            {
                foreach(var property in includeProperties)
                {
                    entity = entity.Include(property);
                }
            }

            return await entity.ToListAsync();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> entity = _context.Set<T>();

            if(includeProperties != null)
            {
                foreach(var property in includeProperties)
                {
                    entity = entity.Include(property);
                }
            }

            return entity.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry toUpdate = _context.Set<T>().Update(entity);

            toUpdate.State = EntityState.Modified;

            return toUpdate != null;
        }
    }
}
