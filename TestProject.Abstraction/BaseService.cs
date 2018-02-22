using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.Abstraction
{
    public abstract class BaseService<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        protected BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }


        public Task<TEntity> AddAsync(TEntity entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task DeleteByIdAsync(int id)
        {
            return _repository.DeleteByIdAsync(id);
        }
    }
}