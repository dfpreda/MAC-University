using AutoMapper;
using MAC.Data.Entities;

namespace MAC.Data.DTO.Profiles
{
    public class ClassesProfile : Profile
    {
        public ClassesProfile()
        {
            CreateMap<Class, ClassDTO>();
            CreateMap<ClassDTO, Class>()
                .ForMember(dst => dst.ClassGroups, map => map.MapFrom(src => src.ClassGroups));
        }
    }
}
