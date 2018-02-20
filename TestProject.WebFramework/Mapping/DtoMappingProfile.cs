using AutoMapper;
using TestProject.Domain;
using TestProject.WebFramework.Dto;

namespace TestProject.WebFramework.Mapping
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Group, GroupListItemViewModel>();
            CreateMap<GroupCreateBindingModel, Group>();
            CreateMap<User, UserListItemViewModel>();
            CreateMap<UserCreateBindingModel, User>();
        }
    }
}
