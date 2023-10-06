using Microsoft.EntityFrameworkCore;
using RCLocacoes.Domain.Entities;
using RCLocacoes.Infra.Data.Context;
using System.Linq.Expressions;

namespace RCLocacoes.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<TEntity> dbSet;

        protected BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            dbSet.Add(obj);
            contexto.SaveChangesAsync();
        }
        public virtual IQueryable<TEntity> List()
        {
            return dbSet.AsQueryable();
        }
        public virtual TEntity GetFirstByExp(Expression<Func<TEntity, bool>> query)
        {
            return dbSet.FirstOrDefault(query);
        }
        public virtual IQueryable<TEntity> FilteredList(Expression<Func<TEntity, bool>> query)
        {
            return dbSet.Where(query);
        }

        public Task AddAsync(TEntity obj)
        {
            return dbSet.AddAsync(obj).AsTask();
        }

        public Task AddAsync(IEnumerable<TEntity> objs)
        {
            return dbSet.AddRangeAsync(objs);
        }

        public void Delete(TEntity obj)
        {
            dbSet.Remove(obj);
        }

        public void Delete(IEnumerable<TEntity> objs)
        {
            dbSet.RemoveRange(objs);
        }

        public void Update(TEntity obj)
        {
            dbSet.Update(obj);
            dbSet.Entry(obj).State = EntityState.Modified;
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.AnyAsync(where);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);

        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, bool asNoTracking)
        {
            if (asNoTracking)
            {
                return await dbSet
                    .AsNoTracking()
                    .Where(where)
                    .ToListAsync();
            }

            return await dbSet
                .Where(where)
                .ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, bool asNoTracking)
        {
            if (asNoTracking)
            {
                return await dbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(where);
            }

            return await dbSet
                .FirstOrDefaultAsync(where);
        }

        public IQueryable<TEntity> Query
        {
            get { return dbSet; }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
