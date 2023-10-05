using System.Linq.Expressions;

namespace RCLocacoes.Domain.Entities
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        void Add(TEntity obj);
        IQueryable<TEntity> FilteredList(Expression<Func<TEntity, bool>> query);
        TEntity GetFirstByExp(Expression<Func<TEntity, bool>> query);
        IQueryable<TEntity> List();
        void Update(TEntity obj);
        Task AddAsync(TEntity obj);
        Task AddAsync(IEnumerable<TEntity> objs);
        void Delete(TEntity obj);
        void Delete(IEnumerable<TEntity> objs);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, bool asNoTracking);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, bool asNoTracking);
    }
}