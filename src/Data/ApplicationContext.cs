using ApiWorldCup.Domain;
using Microsoft.EntityFrameworkCore;

namespace src.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Departamentos { get; set; }
        public DbSet<Team> Colaboradores { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}