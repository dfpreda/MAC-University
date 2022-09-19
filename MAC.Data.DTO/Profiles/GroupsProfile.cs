using AutoMapper;
using MAC.Data.Entities;

namespace MAC.Data.DTO.Profiles
{
    public class GroupsProfile : Profile
    {
        public GroupsProfile()
        {
            CreateMap<Group, GroupDTO>();
            CreateMap<GroupDTO, Group>()
                .ForMember(dst => dst.Students, map => map.Ignore())
                .ForMember(dst => dst.ClassGroups, map => map.Ignore());
        }
    }
}