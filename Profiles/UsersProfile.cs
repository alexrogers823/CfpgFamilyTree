using AutoMapper;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Profiles
{
    public class UsersProfile : Profile 
    {
        public UsersProfile()
        {
            // Source -> Target 
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}