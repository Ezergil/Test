using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using TestProject.Abstraction;
using TestProject.Domain;
using TestProject.DomainAbstraction;
using TestProject.WebFramework.Dto;

namespace TestProject.Web.Controllers
{
    public abstract class BaseController<TEntity> : ApiController where TEntity : BaseEntity, IGroupParents, new()
    {
        private readonly IService<TEntity> _service;

        protected BaseController(IService<TEntity> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<ListItemViewModel>> Details(int id)
        {
            return Mapper.Map(await ((IGroupParentsService)_service).GetParents(id), new List<ListItemViewModel>());
        }
        public async Task<List<ListItemViewModel>> Get()
        {
            return Mapper.Map(await _service.GetAllAsync(), new List<ListItemViewModel>());
        }
        public async Task<ListItemViewModel> Post(CreateBindingModel model)
        {
            return Mapper.Map(await _service.AddAsync(Mapper.Map(model, new TEntity())), new ListItemViewModel());
        }
        public Task Put(UpdateBindingModel model)
        {
            return ((IGroupParentsService)_service).AddOrRemoveParent(model.Id, model.GroupId);
        }
        public Task Delete(int id)
        {
            return _service.DeleteByIdAsync(id);
        }
    }
}