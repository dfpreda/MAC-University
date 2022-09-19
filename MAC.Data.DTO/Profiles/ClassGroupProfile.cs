using AutoMapper;
using MAC.Data.Entities;

namespace MAC.Data.DTO.Profiles
{
    public class ClassGroupsProfile : Profile
    {
        public ClassGroupsProfile()
        {
            CreateMap<ClassGroup, ClassGroupDTO>();
            CreateMap<ClassGroupDTO, ClassGroup>()
                .ForMember(dst => dst.Group, map => map.Ignore())
                .ForMember(dst => dst.Class, map => map.Ignore());
        }
    }
}