using Microsoft.EntityFrameworkCore;
using PETeca.Domain.Entities;
using PETeca.Domain.Interfaces.Repositories;

namespace PETeca.Infra.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _set;

        public Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _set.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _set.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _set.AddRangeAsync(entities);
        }

        public IQueryable<TEntity> GetAll() 
        {
            return _set;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public TEntity GetById(TKey id)
        {
            return _set.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _set.FindAsync(id);
        }

        public void Remove(params TKey[] ids)
        {
            _set.RemoveRange(_set.Where((TEntity d) => ids.Contains(d.Id)));
        }

        public async Task RemoveAsync(params TKey[] ids)
        {
            foreach (TKey id in ids)
            {
                TEntity entity = await _set.FindAsync(id);
                _set.Remove(entity);
            }
        }

        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }

        public Task RemoveAsync(TEntity entity)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }

        public void Update(TEntity entity)
        { 
            _set.Update(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            TEntity exist = await _set.FindAsync(entity.Id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
        }
    }
}
