using System.Collections.Generic;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    public class TimelineController : ControllerBase
    {
        private readonly ITimelineRepo _repository;

        // GET api/timeline 
        [HttpGet]
        public ActionResult <IEnumerable<TimelineEvent>> GetAllTimelineEvents()
        {
            var timelineItems = _repository.GetAllTimelineEvents();

            return Ok(timelineItems);
        }

        // GET api/timeline/{id} 
        [HttpGet("{id}")]
        public ActionResult <TimelineEvent> GetTimelineEventById(int id)
        {
            var timelineItem = _repository.GetTimelineEventById(id);

            return Ok(timelineItem);
        }
    }
}