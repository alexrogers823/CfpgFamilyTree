using System;
using CfpgFamilyTree.Models;
using Xunit;

namespace CfpgFamilyTree.Tests
{
    public class TimelineEventTests : IDisposable
    {
        TimelineEvent testTimelineEvent;
        public TimelineEventTests()
        {
            testTimelineEvent = new TimelineEvent
            {
                Day = 6,
                Month = 1,
                Year = 2021,
                CreatedByUserId = 1,
                Event = "Idiots breach the capitol"
            };
        }

        public void Dispose()
        {
            testTimelineEvent = null;
        }

        [Fact]
        public void CanChangeEvent()
        {
            // Act 
            testTimelineEvent.Event = "Ossoff wins senate race";

            // Assert 
            Assert.Equal("Ossoff wins senate race", testTimelineEvent.Event);
        }

        [Fact]
        public void CanChangeDate()
        {
            testTimelineEvent.Day = 14;
            testTimelineEvent.Month = 2;
            testTimelineEvent.Year = 2020;

            Assert.Equal(2, testTimelineEvent.Month);
            Assert.Equal(14, testTimelineEvent.Day);
            Assert.Equal(2020, testTimelineEvent.Year);
        }

        // TODO: Write test(s) for testing null values 
  }
}