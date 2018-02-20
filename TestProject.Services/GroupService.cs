using TestProject.Abstraction;
using TestProject.Domain;
using TestProject.DomainAbstraction;

namespace TestProject.Services
{
    public class GroupService : DomainService<Group>, IGroupService
    {
        public GroupService(IRepository<Group> repository) : base(repository)
        {
        }
    }
}