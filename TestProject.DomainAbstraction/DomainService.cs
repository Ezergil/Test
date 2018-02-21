using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Abstraction;
using TestProject.Common.Extensions;
using TestProject.Domain;

namespace TestProject.DomainAbstraction
{
    public abstract class DomainService<TEntity> : BaseService<TEntity>, IGroupParentsService where TEntity: BaseEntity, IGroupParents, new()
    {
        protected DomainService(IRepository<TEntity> repository) : base(repository)
        {
            
        }

        public async Task<IEnumerable<Group>> GetParents(int entityId)
        {
            var entity = await GetByIdAsync(entityId);
            return entity.Parents.Flatten(p => p.Parents).Distinct();
        }

        /// <summary>
        /// Removes parent group if exists and otherwise
        /// </summary>
        /// <param name="entityId">id of an IGroupParents entity</param>
        /// <param name="parentId">id of a parent group</param>
        /// <returns></returns>
        public async Task AddOrRemoveParent(int entityId, int parentId)
        {
            var entity = await GetByIdAsync(entityId);
            var parent = entity.Parents.FirstOrDefault(p => p.Id == parentId);
            if (!entity.Parents.Remove(parent))
            {
                entity.Parents.Add(await GetByIdAsync(parentId) as Group);
            }
            await UpdateAsync(entity);
        }
    }
}