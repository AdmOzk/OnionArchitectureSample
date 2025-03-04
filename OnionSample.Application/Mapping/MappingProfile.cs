using AutoMapper;
using OnionSample.Application.DTOs;
using OnionSample.Domain.Entities;
using System;

namespace OnionSample.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Product to ProductDto (convert enum to string)
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            // Map ProductDto to Product (convert string back to enum)
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    (ProductStatus)Enum.Parse(typeof(ProductStatus), src.Status)));
        }
    }
}
