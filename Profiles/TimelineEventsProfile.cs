using AutoMapper;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Profiles
{
    public class TimelineEventsProfile : Profile 
    {
        public TimelineEventsProfile()
        {
            // Source -> Target 
            CreateMap<TimelineEvent, TimelineEventReadDto>();
            CreateMap<TimelineEventCreateDto, TimelineEvent>();
        }
    }
}