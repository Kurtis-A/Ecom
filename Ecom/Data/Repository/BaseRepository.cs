using System.Collections.Generic;
using System.Threading.Tasks;
using Ecom.Data.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Data.Repository
{
    public abstract class BaseRepository<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
    {
        internal readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Find(int id) => await _context.Set<TEntity>().FindAsync(id);

        public virtual async Task<List<TEntity>> FindAll() => await _context.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return entity;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
