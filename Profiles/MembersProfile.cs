using AutoMapper;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Profiles
{
    public class MembersProfile : Profile 
    {
        public MembersProfile()
        {
            // Source -> Target 
            CreateMap<Member, MemberReadDto>();
            CreateMap<MemberCreateDto, Member>();
        }
    }
}