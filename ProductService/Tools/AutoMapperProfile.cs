using System.Collections.Generic;
using ProductService.Models;
using ProductService.DTOs;

namespace ProductService.Tools
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
