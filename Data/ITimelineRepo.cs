using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public interface ITimelineRepo
    {
        IEnumerable<TimelineEvent> GetAllTimelineEvents();
        TimelineEvent GetTimelineEventById(int id);
    }
}