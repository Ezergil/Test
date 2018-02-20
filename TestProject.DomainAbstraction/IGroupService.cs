using TestProject.Abstraction;
using TestProject.Domain;

namespace TestProject.DomainAbstraction
{
    public interface IGroupService : IService<Group>, IGroupParentsService
    {
        
    }
}