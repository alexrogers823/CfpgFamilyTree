using System.Collections.Generic;
using System.Linq;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
  public class SqlTimelineRepo : ITimelineRepo
  {
    private readonly TimelineContext _context;

    public SqlTimelineRepo(TimelineContext context)
    {
        _context = context;
    }
    public IEnumerable<TimelineEvent> GetAllTimelineEvents()
    {
        return _context.TimelineEvents.ToList();
    }

    public TimelineEvent GetTimelineEventById(int id)
    {
        return _context.TimelineEvents.FirstOrDefault(p => p.Id == id);
    }
  }
}