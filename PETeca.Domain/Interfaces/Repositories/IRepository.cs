namespace PETeca.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        IQueryable<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        TEntity GetById(TKey id);
        Task<TEntity> GetByIdAsync(TKey id);
        void Remove(params TKey[] ids);
        Task RemoveAsync(params TKey[] ids);
        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
