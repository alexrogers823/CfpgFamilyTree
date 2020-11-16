using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public interface ITimelineRepo
    {
        bool SaveChanges();
        IEnumerable<TimelineEvent> GetAllTimelineEvents();
        TimelineEvent GetTimelineEventById(int id);
        void CreateTimelineEvent(TimelineEvent timelineEvent);
    }
}