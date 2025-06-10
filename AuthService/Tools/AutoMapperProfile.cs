using AuthService.DTOs;
using AuthService.Models;

namespace AuthService.Tools
{
    public class AutoMapperProfile : AutoMapper.Profile

    {
        public AutoMapperProfile()
        {

            CreateMap<LoginDTO, User>().ReverseMap();

            CreateMap<RegisterDTO, User>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<RoleUpdateDTO, Role>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserUpdateDTO, User>().ReverseMap()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));  
        }
    }
}
