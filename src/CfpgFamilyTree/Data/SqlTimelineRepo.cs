using System;
using System.Collections.Generic;
using System.Linq;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
  public class SqlTimelineRepo : ITimelineRepo
  {
    private readonly CfpgContext _context;

    public SqlTimelineRepo(CfpgContext context)
    {
        _context = context;
    }

    public void CreateTimelineEvent(TimelineEvent timelineEvent)
    {
        if(timelineEvent == null)
        {
            throw new ArgumentNullException(nameof(timelineEvent));
        }

        _context.TimelineEvents.Add(timelineEvent);
    }

        public void DeleteTimelineEvent(TimelineEvent timelineEvent)
        {
            if(timelineEvent == null)
            {
                throw new ArgumentNullException(nameof(timelineEvent));
            }

            _context.TimelineEvents.Remove(timelineEvent);
        }

    public IEnumerable<TimelineEvent> GetAllTimelineEvents()
    {
        return _context.TimelineEvents.ToList();
    }

    public TimelineEvent GetTimelineEventById(int id)
    {
        return _context.TimelineEvents.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public void UpdateTimelineEvent(TimelineEvent timelineEvent)
    {
      
    }
  }
}