using System.Collections.Generic;
using System.Threading.Tasks;
using Ecom.Data.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Data.Repository
{
    public abstract class BaseRepository<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
    {
        internal readonly TContext context;

        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public virtual async Task<TEntity> Find(int id) => await context.Set<TEntity>().FindAsync(id);

        public virtual async Task<List<TEntity>> FindAll() => await context.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return entity;

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
