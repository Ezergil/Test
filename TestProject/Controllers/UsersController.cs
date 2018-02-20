using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using TestProject.Domain;
using TestProject.DomainAbstraction;
using TestProject.WebFramework.Dto;

namespace TestProject.Web.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [Route("{id}/details")]
        public async Task<IEnumerable<GroupListItemViewModel>> Details(int id)
        {
            return Mapper.Map(await _service.GetParents(id), new List<GroupListItemViewModel>());
        }
        public async Task<List<UserListItemViewModel>> Get()
        {
            return Mapper.Map(await _service.GetAllAsync(), new List<UserListItemViewModel>());
        }
        public Task Post(UserCreateBindingModel model)
        {
            return _service.AddAsync(Mapper.Map(model, new User()));
        }
        public Task Put(UserUpdateBindingModel model)
        {
            return _service.AddOrRemoveParent(model.Id, model.GroupId);
        }
        public Task Delete(int id)
        {
            return _service.DeleteByIdAsync(id);
        }
    }
}