using System.Linq;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>().ForMember(des => des.PhotoUrl, opt => opt.MapFrom(src => src.photos.FirstOrDefault(x => x.IsMain).Url)).ForMember(des => des.Age , opt => opt.MapFrom(src => src.Age.FirstOrDefault(x => x)))
            CreateMap<Photo, PhotoDto>();

        }
    }
}