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
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
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

            // TPT configuration: each type gets its own table
            modelBuilder.Entity<Persona>().ToTable("Personas");
            modelBuilder.Entity<Alumno>().ToTable("Alumnos");
            modelBuilder.Entity<Profesor>().ToTable("Profesores");

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
                .WithOne()
                .HasForeignKey<Usuario>(u => u.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Usuario)
                .WithOne()
                .HasForeignKey<Alumno>(a => a.UsuarioId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Profesor>()
                .HasOne(p => p.Usuario)
                .WithOne() 
                .HasForeignKey<Profesor>(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasOne(ai => ai.Alumno)
                .WithMany()
                .HasForeignKey(ai => ai.AlumnoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AlumnoInscripcion>()
                .HasOne(ai => ai.Curso)
                .WithMany()
                .HasForeignKey(ai => ai.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProfesorCurso>()
                .HasOne(pc => pc.Profesor)
                .WithMany()
                .HasForeignKey(pc => pc.ProfesorId)
                .OnDelete(DeleteBehavior.Cascade);
    
            modelBuilder.Entity<ProfesorCurso>()
                .HasOne(pc => pc.Curso)
                .WithMany()
                .HasForeignKey(pc => pc.CursoId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    } 
}
