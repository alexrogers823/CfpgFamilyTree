using AutoMapper;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Profiles
{
    public class FaqProfile : Profile
    {
        public FaqProfile()
        {
            CreateMap<Faq, FaqReadDto>();
            CreateMap<FaqCreateDto, Faq>();
            CreateMap<FaqUpdateDto, Faq>();
            CreateMap<Faq, FaqUpdateDto>();
        }        
    }
}