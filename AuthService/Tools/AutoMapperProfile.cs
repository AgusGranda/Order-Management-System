using AuthService.DTOs;
using AuthService.Models;

namespace AuthService.Tools
{
    public class AutoMapperProfile : AutoMapper.Profile

    {
        public AutoMapperProfile()
        {

            CreateMap<LoginDTO, User>().ReverseMap();
            CreateMap<RegisterDTO, User>().ReverseMap();

        }
    }
}
