using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

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
        public DbSet<AlumnoInscripcion> AlumnosInscripciones { get; set; }
        public DbSet<ProfesorCurso> ProfesoresCursos { get; set; }

        public TPIContext()
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

            // Relaciones
            modelBuilder.Entity<Materia>()
                .HasOne(p => p.Plan)
                .WithMany()
                .HasForeignKey(p => p.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comision>()
                .HasOne(c => c.Plan)
                .WithMany()
                .HasForeignKey(c => c.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Materia)
                .WithMany()
                .HasForeignKey(c => c.MateriaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithMany()
                .HasForeignKey(u => u.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Plan)
                .WithMany()
                .HasForeignKey(u => u.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasOne(ai => ai.Usuario)
                .WithMany()
                .HasForeignKey(ai => ai.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasOne(ai => ai.Curso)
                .WithMany()
                .HasForeignKey(ai => ai.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProfesorCurso>()
                .HasOne(pc => pc.Usuario)
                .WithMany()
                .HasForeignKey(pc => pc.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProfesorCurso>()
                .HasOne(pc => pc.Curso)
                .WithMany()
                .HasForeignKey(pc => pc.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Datos semilla
            modelBuilder.Entity<Persona>().HasData(new Persona
            {
                Id = 1,
                Nombre = "Admin",
                Apellido = "Sistema",
                Dni = 1
            });

            var adminSalt = Guid.NewGuid().ToString();
            var adminClave = HashPassword("1234", adminSalt);

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                NombreUsuario = "admin",
                Email = "admin@correo.com",
                Clave = adminClave,
                Salt = adminSalt,
                Habilitado = true,
                Tipo = "Administrador",
                Legajo = string.Empty,
                PersonaId = 1,
                PlanId = null
            });
        }

        private static string HashPassword(string password, string salt)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var combined = password + salt;
                var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(combined));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}