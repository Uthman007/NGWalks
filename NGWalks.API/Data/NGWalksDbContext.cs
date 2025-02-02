using Microsoft.EntityFrameworkCore;
using NGWalks.API.Models.Domain;

namespace NGWalks.API.Data
{
    public class NGWalksDbContext: DbContext
    {
        public NGWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

    }
}
