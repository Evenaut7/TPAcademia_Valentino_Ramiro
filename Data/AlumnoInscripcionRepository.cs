using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            context.AlumnosInscripciones.Add(alumnoInscripcion);
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
                .Include(ai => ai.Alumno)
                .Include(ai => ai.Curso)
                .FirstOrDefault(ai => ai.Id == id);
        }

        public IEnumerable<AlumnoInscripcion> GetAll()
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Include(ai => ai.Alumno)
                .Include(ai => ai.Curso)
                .ToList();
        }

        public bool Update(AlumnoInscripcion alumnoInscripcion)
        {
            using var context = CreateContext();
            var existingAlumnoInscripcion = context.AlumnosInscripciones.Find(alumnoInscripcion.Id);
            if (existingAlumnoInscripcion != null)
            {
                existingAlumnoInscripcion.AlumnoId = alumnoInscripcion.AlumnoId;
                existingAlumnoInscripcion.CursoId = alumnoInscripcion.CursoId;
                existingAlumnoInscripcion.Condicion = alumnoInscripcion.Condicion;
                existingAlumnoInscripcion.Nota = alumnoInscripcion.Nota;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(int alumnoId, int cursoId)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones.Any(ai => ai.AlumnoId == alumnoId && ai.CursoId == cursoId);
        }

        public IEnumerable<AlumnoInscripcion> GetByAlumnoId(int alumnoId)
        {
            using var context = CreateContext();
            return context.AlumnosInscripciones
                .Include(ai => ai.Alumno)
                .Include(ai => ai.Curso)
                .Where(ai => ai.AlumnoId == alumnoId)
                .ToList();
        }
    }
}
