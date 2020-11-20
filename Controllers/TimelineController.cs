using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    [Route("api/timeline")]
    [ApiController]
    public class TimelineController : ControllerBase
    {
        private readonly ITimelineRepo _repository;
        private readonly IMapper _mapper;

        // private readonly MockTimelineRepo _repository = new MockTimelineRepo();

        public TimelineController(ITimelineRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        // GET api/timeline 
        [HttpGet]
        public ActionResult <IEnumerable<TimelineEvent>> GetAllTimelineEvents()
        {
            var timelineItems = _repository.GetAllTimelineEvents();

            return Ok(_mapper.Map<IEnumerable<TimelineEventReadDto>>(timelineItems));
        }

        // GET api/timeline/{id} 
        [HttpGet("{id}", Name="GetTimelineEventById")]
        public ActionResult <TimelineEvent> GetTimelineEventById(int id)
        {
            var timelineItem = _repository.GetTimelineEventById(id);
            if(timelineItem != null)
            {
                return Ok(_mapper.Map<TimelineEventReadDto>(timelineItem));
            }
            return NotFound();
        }

        // POST api/timeline 
        [HttpPost]
        public ActionResult <TimelineEventCreateDto> CreateTimelineEvent(TimelineEventCreateDto timelineEventCreateDto)
        {
            var timelineItemModel = _mapper.Map<TimelineEvent>(timelineEventCreateDto);
            _repository.CreateTimelineEvent(timelineItemModel);
            _repository.SaveChanges();

            var timelineItemReadDto = _mapper.Map<TimelineEventReadDto>(timelineItemModel);

            return CreatedAtRoute(nameof(GetTimelineEventById), new {Id = timelineItemReadDto.Id}, timelineItemReadDto);
        }

    }
}