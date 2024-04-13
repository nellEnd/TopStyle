using AutoMapper;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Domain.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            /*   CreateMap<Order, PlaceOrderDTO>()
                   .ForMember(dest => dest.OrderId,
                   option => option.MapFrom(src => src.OrderId))
                   .ForMember(dest => dest.UserId,
                   option => option.MapFrom(src => src.UserId))
                   .ForMember(dest => dest.Products,
                   option => option.MapFrom(src => src.Products.Select(p => p.ProductId).ToList()))
                   .ReverseMap();*/

            CreateMap<Order, PlaceOrderDTO>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(p => p.ProductId).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<PlaceOrderDTO, Order>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Products, opt => opt.Ignore()); // Ignore Products during reverse mapping

        }
    }
}
