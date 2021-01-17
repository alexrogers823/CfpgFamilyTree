using System;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using CfpgFamilyTree.Models;
using CfpgFamilyTree.Data;
using CfpgFamilyTree.Profiles;
using CfpgFamilyTree.Controllers;
using CfpgFamilyTree.Dtos;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace CfpgFamilyTree.Tests
{
    public class TimelineEventControllerTests
    {

        [Fact]
        public void GetTimelineEventItems_Returns200OK_WhenDBIsEmpty()
        {
            // Arrange 
            var mockRepo = new Mock<ITimelineRepo>();

            mockRepo.Setup(repo => repo.GetAllTimelineEvents()).Returns(GetTimelineEvent(0));

            var realProfile = new TimelineEventsProfile();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));

            IMapper mapper = new Mapper(configuration);

            var controller = new TimelineController(mockRepo.Object, mapper);

            // Act 
            var result = controller.GetAllTimelineEvents();

            // Assert 
            Assert.IsType<OkObjectResult>(result.Result);
        }

        private List<TimelineEvent> GetTimelineEvent(int num)
        {
            var timelineEvents = new List<TimelineEvent>();
            if (num > 0)
            {
                timelineEvents.Add(new TimelineEvent
                {
                    Id = 0,
                    Day = 4,
                    Month = 11,
                    Year = 2020,
                    CreatedByUserId = 823,
                    Event = "Agent Orange is Fired"
                });
            }

            return timelineEvents;
        }
    }
}