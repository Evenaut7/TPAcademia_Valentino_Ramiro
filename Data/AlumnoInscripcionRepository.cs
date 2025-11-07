using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AlumnoInscripcionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = CreateContext();

            // Validar que el usuario existe y es alumno
            var usuario = context.Usuarios.Find(alumnoInscripcion.UsuarioId);
            if (usuario == null)
                throw new Exception($"No existe un usuario con ID '{alumnoInscripcion.UsuarioId}'.");
            if (usuario.Tipo != "Alumno")
                throw new Exception($"Solo los alumnos pueden inscribirse a materias. El usuario es de tipo '{usuario.Tipo}'.");

            // Validar que el curso existe
            var curso = context.Cursos.Find(alumnoInscripcion.CursoId);
            if (curso == null)
                throw new Exception($"No existe un curso con ID '{alumnoInscripcion.CursoId}'.");

            // Validar comisión y plan
            var comision = context.Comisiones.Find(curso.ComisionId);
            if (comision == null)
                throw new Exception("La comisión del curso no existe.");
            if (usuario.PlanId != comision.PlanId)
                throw new Exception("No puedes inscribirte en cursos fuera de tu plan.");

            // Validar cupo
            if (curso.Cupo <= 0)
                throw new Exception("No hay cupo disponible para este curso.");

            // Validar que no exista otra inscripción
            if (context.AlumnosInscripciones.Any(ai => ai.UsuarioId == alumnoInscripcion.UsuarioId && ai.CursoId == alumnoInscripcion.CursoId))
                throw new Exception($"El usuario con ID '{alumnoInscripcion.UsuarioId}' ya está inscrito en el curso con ID '{alumnoInscripcion.CursoId}'.");

            // Restar el cupo
            curso.Cupo--;

            // Agregar la inscripción
            context.AlumnosInscripciones.Add(alumnoInscripcion);

            // Guardar cambios en una sola transacción
            context.SaveChanges();
        }
        public bool Delete(int id)
        {
            using var context = CreateContext();
            var alumnoInscripcion = context.AlumnosInscripciones.Find(id);
            if (alumnoInscripcion != null)
            {
                context.AlumnosInscripciones.Remove(alumnoInscripcion);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public AlumnoInscripcion? Get(int id)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Include(ai => ai.Usuario)
                .Include(ai => ai.Curso)
                .FirstOrDefault(ai => ai.Id == id);
        }
        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Include(ai => ai.Usuario)
                .Include(ai => ai.Curso)
                .ToList();
        }
        public bool Update(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = CreateContext();
            var existingAlumnoInscripcion = context.AlumnosInscripciones.Find(alumnoInscripcion.Id);
            if (existingAlumnoInscripcion != null)
            {
                existingAlumnoInscripcion.UsuarioId = alumnoInscripcion.UsuarioId;
                existingAlumnoInscripcion.CursoId = alumnoInscripcion.CursoId;
                existingAlumnoInscripcion.Condicion = alumnoInscripcion.Condicion;
                existingAlumnoInscripcion.Nota = alumnoInscripcion.Nota;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Exists(int usuarioId, int cursoId)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones.Any(ai => ai.UsuarioId == usuarioId && ai.CursoId == cursoId);
        }
        public IEnumerable<AlumnoInscripcion> GetByUsuarioId(int usuarioId)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Include(ai => ai.Usuario)
                .Include(ai => ai.Curso)
                .Where(ai => ai.UsuarioId == usuarioId)
                .ToList();
        }
    }
}
