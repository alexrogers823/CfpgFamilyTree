using AutoMapper;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Profiles
{
    public class PhotosProfile : Profile 
    {
        public PhotosProfile()
        {
            // Source -> Target 
            CreateMap<Photo, PhotoReadDto>();
            CreateMap<PhotoCreateDto, Photo>();
        }
    }
}