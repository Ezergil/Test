using TestProject.Abstraction;
using TestProject.Domain;
using TestProject.DomainAbstraction;

namespace TestProject.Services
{
    public sealed class UserService : DomainService<User>, IUserService
    {
        public UserService(IRepository<User> repository, IRepository<Group> parentRepository) : base(repository, parentRepository)
        {
        }
    }
}