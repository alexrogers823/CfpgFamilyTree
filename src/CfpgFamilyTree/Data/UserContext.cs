using CfpgFamilyTree.Models;
using Microsoft.EntityFrameworkCore;

namespace CfpgFamilyTree.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}