using Microsoft.EntityFrameworkCore;
using Models;

namespace ApiAcademia.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Plan> Plan { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
