using AutoMapper;
using TestProject.Domain;
using TestProject.WebFramework.Dto;

namespace TestProject.WebFramework.Mapping
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Group, ListItemViewModel>();
            CreateMap<CreateBindingModel, Group>();
            CreateMap<User, ListItemViewModel>();
            CreateMap<CreateBindingModel, User>();
        }
    }
}
