using TestProject.Abstraction;
using TestProject.Domain;

namespace TestProject.DomainAbstraction
{
    public interface IUserService : IService<User>, IGroupParentsService
    {
        
    }
}