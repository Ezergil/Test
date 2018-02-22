using TestProject.Domain;
using TestProject.DomainAbstraction;

namespace TestProject.Web.Controllers
{
    public sealed class UsersController : BaseController<User>
    {
        public UsersController(IUserService service) : base(service)
        {
        }
    }
}