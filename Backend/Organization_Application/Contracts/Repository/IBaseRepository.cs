
namespace TQMS_Organization_Application.Contracts.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        Task DeleteByIdAsync(Guid id);
        Task SaveChanges();
        Task<IEnumerable<TResult>> GetFilteredListAsync<TResult>(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TResult>> selector);
        Task<IEnumerable<TEntity>> GetFilteredListAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);

        Task<TResult> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);
        Task<IEnumerable<TResult>> GetFilteredListAsync<TResult>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> orderBy,
            Expression<Func<TEntity, TResult>> selector,
            bool descending = false);

    }
}
