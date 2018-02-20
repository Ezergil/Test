using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using TestProject.Domain;
using TestProject.DomainAbstraction;
using TestProject.WebFramework.Dto;

namespace TestProject.Web.Controllers
{
    public class GroupsController : ApiController
    {
        private readonly IGroupService _service;

        public GroupsController(IGroupService service)
        {
            _service = service;
        }
        [Route("{id}/details")]
        public async Task<IEnumerable<GroupListItemViewModel>> Details(int id)
        {
            return Mapper.Map(await _service.GetParents(id), new List<GroupListItemViewModel>());
        }
        public async Task<List<GroupListItemViewModel>> Get()
        {
            return Mapper.Map(await _service.GetAllAsync(), new List<GroupListItemViewModel>());
        }
        public Task Post(GroupCreateBindingModel model)
        {
            return _service.AddAsync(Mapper.Map(model, new Group()));
        }
        public Task Put(GroupUpdateBindingModel model)
        {
            return _service.AddOrRemoveParent(model.Id, model.GroupId);
        }
        public Task Delete(int id)
        {
            return _service.DeleteByIdAsync(id);
        }
    }
}
