using System.Web.Http;
using TestProject.Domain;
using TestProject.DomainAbstraction;

namespace TestProject.Web.Controllers
{
    [RoutePrefix("api/groups")]
    public sealed class GroupsController : BaseController<Group>
    {
        public GroupsController(IGroupService service) : base(service)
        {
        }
    }
}
