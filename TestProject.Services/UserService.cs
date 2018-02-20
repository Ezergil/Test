using TestProject.Abstraction;
using TestProject.Domain;
using TestProject.DomainAbstraction;

namespace TestProject.Services
{
    public class UserService : DomainService<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}