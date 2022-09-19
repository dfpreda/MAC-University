using AutoMapper;
using MAC.Data.Entities;

namespace MAC.Data.DTO.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>()
                .ForMember(dst => dst.Group, map => map.Ignore())
                .ForMember(dst => dst.Badge, map => map.Ignore());
        }
    }
}