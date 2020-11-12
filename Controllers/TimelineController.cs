using System.Collections.Generic;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Controllers
{
    public class TimelineController : ControllerBase
    {
        private readonly ITimelineRepo _repository;

        [HttpGet]
        public ActionResult <IEnumerable<TimelineEvent>> GetAllTimelineEvents()
        {
            var timelineItems = _repository.GetAllTimelineEvents();

            return Ok(timelineItems);
        }
    }
}