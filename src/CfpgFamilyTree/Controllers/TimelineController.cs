using System.Collections.Generic;
using AutoMapper;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Dtos;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult <IEnumerable<TimelineEventReadDto>> GetAllTimelineEvents()
        {
            var timelineItems = _repository.GetAllTimelineEvents();

            return Ok(_mapper.Map<IEnumerable<TimelineEventReadDto>>(timelineItems));
        }

        // GET api/timeline/{id} 
        [HttpGet("{id}", Name="GetTimelineEventById")]
        public ActionResult <TimelineEventReadDto> GetTimelineEventById(int id)
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
        public ActionResult <TimelineEventReadDto> CreateTimelineEvent(TimelineEventCreateDto timelineEventCreateDto)
        {
            var timelineItemModel = _mapper.Map<TimelineEvent>(timelineEventCreateDto);
            _repository.CreateTimelineEvent(timelineItemModel);
            _repository.SaveChanges();

            var timelineItemReadDto = _mapper.Map<TimelineEventReadDto>(timelineItemModel);

            return CreatedAtRoute(nameof(GetTimelineEventById), new {Id = timelineItemReadDto.Id}, timelineItemReadDto);
        }

        // PATCH api/timeline/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateTimelineEvent(int id, JsonPatchDocument<TimelineEventUpdateDto> patchDoc)
        {
            var timelineEventModel = _repository.GetTimelineEventById(id);

            if(timelineEventModel == null)
            {
                return NotFound();
            }

            var timelineEventPatch = _mapper.Map<TimelineEventUpdateDto>(timelineEventModel);
            patchDoc.ApplyTo(timelineEventPatch, ModelState);
            if(!TryValidateModel(timelineEventPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(timelineEventPatch, timelineEventModel);

            _repository.UpdateTimelineEvent(timelineEventModel);
            _repository.SaveChanges();

            return NoContent();
        }
        
        // DELETE api/timeline/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTimelineEvent(int id)
        {
            var timelineEventModel = _repository.GetTimelineEventById(id);

            if(timelineEventModel == null)
            {
                return NotFound();
            }

            _repository.DeleteTimelineEvent(timelineEventModel);
            _repository.SaveChanges();

            return NoContent();

        }

    }
}