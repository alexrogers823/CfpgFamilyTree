using AutoMapper;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Profiles
{
    public class ArtifactsProfile : Profile
    {
        public ArtifactsProfile()
        {
            // Source -> Target 
            CreateMap<Artifact, ArtifactReadDto>();
            CreateMap<ArtifactCreateDto, Artifact>();
            CreateMap<ArtifactUpdateDto, Artifact>();
            CreateMap<Artifact, ArtifactUpdateDto>();
        }
    }
}