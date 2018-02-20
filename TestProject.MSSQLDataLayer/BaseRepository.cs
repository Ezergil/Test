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

        public Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return _context.CommitAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _dbSet.FirstAsync(e => e.Id == id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _context.SetAsModified(entity);
            return _context.CommitAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            _context.SetAsDeleted(new TEntity { Id = id });
            return _context.CommitAsync();
        }
    }
}