using CfpgFamilyTree.Models;
using Microsoft.EntityFrameworkCore;

namespace CfpgFamilyTree.Data
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> opt) : base(opt)
        {
            
        }

        public DbSet<Member> Members { get; set; }
    }
}