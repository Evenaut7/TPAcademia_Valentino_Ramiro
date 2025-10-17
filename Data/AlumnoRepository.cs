using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public class AlumnoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Alumno alumno)
        {
            using var context = CreateContext();
            context.Alumnos.Add(alumno);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var alumno = context.Alumnos.Find(id);
            if (alumno != null)
            {
                context.Alumnos.Remove(alumno);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public Alumno? Get(int id)
        {
            using var context = CreateContext();
            return context.Alumnos
                .FirstOrDefault(a => a.Id == id);
        }
        public IEnumerable<Alumno> GetAll()
        {
            using var context = CreateContext();
            return context.Alumnos.ToList();
        }
        public bool Update(Alumno alumno)
        {
            using var context = CreateContext();
            var existingAlumno = context.Alumnos.Find(alumno.Id);
            if (existingAlumno != null)
            {
                existingAlumno.Nombre = alumno.Nombre;
                existingAlumno.Apellido = alumno.Apellido;
                existingAlumno.Dni = alumno.Dni;
                existingAlumno.FechaNacimiento = alumno.FechaNacimiento;
                existingAlumno.Legajo = alumno.Legajo;

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(int alumnoId, int profesorId)
        {
            using var context = CreateContext();
            return context.Alumnos.Any(a => a.Id == alumnoId) || context.Profesores.Any(p => p.Id == profesorId);
        }
    }
}
