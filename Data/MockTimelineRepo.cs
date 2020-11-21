using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
  public class MockTimelineRepo : ITimelineRepo
  {
    public void CreateTimelineEvent(TimelineEvent timelineEvent)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<TimelineEvent> GetAllTimelineEvents()
    {
        var timelineEvents = new List<TimelineEvent>
        {
            new TimelineEvent{ Id=0, Day=23, Month=8, Year=1994, Event="I was born"},
            new TimelineEvent{ Id=1, Day=9, Month=5, Year=2016, Event="I graduated college"},
            new TimelineEvent{ Id=2, Day=21, Month=1, Year=2019, Event="I switched into tech"}
        };

        return timelineEvents;
    }

    public TimelineEvent GetTimelineEventById(int id)
    {
        return new TimelineEvent{ Id=0, Day=23, Month=8, Year=1994, Event="I was born"};
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }

    public void UpdateTimelineEvent(TimelineEvent timelineEvent)
    {
      throw new System.NotImplementedException();
    }
  }
}