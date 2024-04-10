using AutoMapper;
using TopStyle_Inlamning2.Domain.DTO;
using TopStyle_Inlamning2.Domain.Entities;

namespace TopStyle_Inlamning2.Domain.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserId,
                option => option.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Username,
                option => option.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password,
                option => option.MapFrom(src => src.Password))
                .ReverseMap();
                
                
   
        }                           
    }
}
