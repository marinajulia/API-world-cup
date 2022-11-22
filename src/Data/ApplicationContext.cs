using ApiWorldCup.Domain;
using Microsoft.EntityFrameworkCore;

namespace src.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}