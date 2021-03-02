using CfpgFamilyTree.Models;
using Microsoft.EntityFrameworkCore;

namespace CfpgFamilyTree.Data
{
    public class CfpgContext : DbContext
    {
        public CfpgContext(DbContextOptions<CfpgContext> opt) : base(opt)
        {
            
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<TimelineEvent> TimelineEvents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<Faq> Questions { get; set; }
    }
}