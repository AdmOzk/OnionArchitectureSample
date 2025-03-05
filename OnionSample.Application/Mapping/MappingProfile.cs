using AutoMapper;
using OnionSample.Application.DTOs;
using OnionSample.Domain.Entities;

namespace OnionSample.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
