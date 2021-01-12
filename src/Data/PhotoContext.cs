using CfpgFamilyTree.Models;
using Microsoft.EntityFrameworkCore;

namespace CfpgFamilyTree.Data
{
    public class PhotoContext : DbContext
    {
        public PhotoContext(DbContextOptions<PhotoContext> opt) : base(opt)
        {
            
        }

        public DbSet<Photo> Photos { get; set; }
    }
}