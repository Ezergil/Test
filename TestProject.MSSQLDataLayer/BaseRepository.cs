using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TestProject.Abstraction;

namespace TestProject.MSSQLDataLayer
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly IDbSet<TEntity> _dbSet;
        private readonly IDbContext _context;
        public BaseRepository(IDbContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = _dbSet.Add(entity);
            await _context.CommitAsync();
            return result;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return _dbSet.FirstAsync(e => e.Id == id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.SetAsModified(entity);
            return _context.CommitAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entityToDelete = await GetByIdAsync(id);
            _context.SetAsDeleted(entityToDelete);
            await _context.CommitAsync();
        }
    }
}