using System;
using CfpgFamilyTree.Models;
using Xunit;

namespace CfpgFamilyTree.Tests
{
    public class TimelineEventTests
    {
        [Fact]
        public void CanChangeEvent()
        {
            // Arrange 
            var testTimelineEvent = new TimelineEvent
            {
                Day = 6,
                Month = 1,
                Year = 2021,
                CreatedByUserId = 1,
                Event = "Idiots breach the capitol"
            };

            // Act 
            testTimelineEvent.Event = "Ossoff wins senate race";

            // Assert 
            Assert.Equal("Ossoff wins senate race", testTimelineEvent.Event);
        }
    }
}