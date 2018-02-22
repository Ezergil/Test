using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.Abstraction
{
    public interface ICrudActions<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task DeleteByIdAsync(int id);
    }
}