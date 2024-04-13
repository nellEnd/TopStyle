using AutoMapper;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;
namespace TopStyle_Inlamning2.Domain.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductId,
                option => option.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName,
                option => option.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Description,
                option => option.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price,
                option => option.MapFrom(src => src.Price))
                .ForMember(dest => dest.CategoryId,
                option => option.MapFrom(src => src.Category.CategoryId)).ReverseMap();
        }
    }
}
