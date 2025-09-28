using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Model;

namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        internal TPIContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>().HasData(
                new Persona
                {
                    Id = -10,
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Dni = 12345678,
                    FechaNacimiento = new DateTime(2000, 1, 1)
                }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = -1,
                    Email = "admin@correo.com",
                    NombreUsuario = "admin",
                    Clave = "1234",
                    PersonaId = -10
                }
            );
            // Materia → Plan (Restrict delete)
            modelBuilder.Entity<Materia>()
                .HasOne(m => m.Plan)
                .WithMany()
                .HasForeignKey(m => m.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comision → Plan (Restrict delete)
            modelBuilder.Entity<Comision>()
                .HasOne(c => c.Plan)
                .WithMany()
                .HasForeignKey(c => c.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Curso → Materia (Cascade or Restrict, but only one should cascade)
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Materia)
                .WithMany()
                .HasForeignKey(c => c.MateriaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithOne()
                .HasForeignKey<Usuario>(u => u.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Usuario)
                .WithOne() 
                .HasForeignKey<Alumno>(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Profesor>()
                .HasOne(p => p.Usuario)
                .WithOne() 
                .HasForeignKey<Profesor>(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); 


        }
    } 
}
