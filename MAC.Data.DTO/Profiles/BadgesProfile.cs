using AutoMapper;
using MAC.Data.Entities;

namespace MAC.Data.DTO.Profiles
{
    public class BadgesProfile : Profile
    {
        public BadgesProfile()
        {
            CreateMap<Badge, BadgeDTO>();
            CreateMap<BadgeDTO, Badge>()
                .ForMember(dst => dst.Student, map => map.Ignore());
        }
    }
}