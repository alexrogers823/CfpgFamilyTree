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
    public class TimelineEventControllerTests : IDisposable
    {
        Mock<ITimelineRepo> mockRepo;
        TimelineEventsProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public TimelineEventControllerTests()
        {
            mockRepo = new Mock<ITimelineRepo>();
            realProfile = new TimelineEventsProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            realProfile = null;
            configuration = null;
            mapper = null;
        }

        [Fact]
        public void GetTimelineEventItems_Returns200OK_WhenDBIsEmpty()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetAllTimelineEvents()).Returns(GetTimelineEvents(0));

            var controller = new TimelineController(mockRepo.Object, mapper);

            // Act 
            var result = controller.GetAllTimelineEvents();

            // Assert 
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetTimelineEventItems_ReturnsOneItem_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllTimelineEvents()).Returns(GetTimelineEvents(1));

            var controller = new TimelineController(mockRepo.Object, mapper);

            var result = controller.GetAllTimelineEvents();

            var okResult = result.Result as OkObjectResult;

            var timelineEvents = okResult.Value as List<TimelineEventReadDto>;

            Assert.Single(timelineEvents);
        }

        [Fact]
        public void GetTimelineEventItems_Returns200OK_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllTimelineEvents()).Returns(GetTimelineEvents(1));

            var controller = new TimelineController(mockRepo.Object, mapper);

            var result = controller.GetAllTimelineEvents();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetTimelineEventItems_ReturnsCorrectType_WhenDBHasOneResource()
        {
            mockRepo.Setup(repo => repo.GetAllTimelineEvents()).Returns(GetTimelineEvents(1));

            var controller = new TimelineController(mockRepo.Object, mapper);

            var result = controller.GetAllTimelineEvents();

            Assert.IsType<ActionResult<IEnumerable<TimelineEventReadDto>>>(result);
        }

        private List<TimelineEvent> GetTimelineEvents(int num)
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