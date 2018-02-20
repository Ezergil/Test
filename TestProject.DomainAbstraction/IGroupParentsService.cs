using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Domain;

namespace TestProject.DomainAbstraction
{
    public interface IGroupParentsService
    {
        Task<IEnumerable<Group>> GetParents(int entityId);
        Task AddOrRemoveParent(int entityId, int parentId);
    }
}
