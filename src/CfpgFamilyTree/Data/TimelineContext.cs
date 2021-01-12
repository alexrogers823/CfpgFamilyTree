using CfpgFamilyTree.Models;
using Microsoft.EntityFrameworkCore;

namespace CfpgFamilyTree.Data
{
    public class TimelineContext : DbContext
    {
        public TimelineContext(DbContextOptions<TimelineContext> opt) : base(opt)
        {
            
        }

        public DbSet<TimelineEvent> TimelineEvents { get; set; }
    }
}