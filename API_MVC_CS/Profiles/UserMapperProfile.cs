using AutoMapper;
using MVC_CS_API.Data.Entities;
using MVC_CS_API.DTO;
using MVC_CS_API.Utils;

namespace MVC_CS_API.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, MemberDTO>()
                .ForMember(
                    dest => dest.Ages,
                    options => options.MapFrom(src => src.DateOfBirth.GetAge())
                );
        }
    }
}
