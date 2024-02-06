using Microsoft.EntityFrameworkCore;
using Superheroes.Models;

namespace Superheroes.DataAccess
{
    public class SuperheroDbContext : DbContext
    {
        public SuperheroDbContext(DbContextOptions<SuperheroDbContext> options) : base(options)
        {
        }

        public DbSet<Superhero> Superheroes { get; set; }
    }
}
