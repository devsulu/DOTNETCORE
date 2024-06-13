using Microsoft.EntityFrameworkCore;

namespace SuperHero.API.Data
{
    public class DataDbContext:DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options):base(options)
        {
                
        }
        public DbSet<SuperHero> superHeroes => Set<SuperHero>();
    }
}
