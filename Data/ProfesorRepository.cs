using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public class ProfesorRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Profesor profesor)
        {
            using var context = CreateContext();
            context.Profesores.Add(profesor);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var profesor = context.Profesores.Find(id);
            if (profesor != null)
            {
                context.Profesores.Remove(profesor);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Profesor? Get(int id)
        {
            using var context = CreateContext();
            return context.Profesores
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Profesor> GetAll()
        {
            using var context = CreateContext();
            return context.Profesores.ToList();
        }

        public bool Update(Profesor profesor)
        {
            using var context = CreateContext();
            var existingProfesor = context.Profesores.Find(profesor.Id);
            if (existingProfesor != null)
            {
                existingProfesor.Nombre = profesor.Nombre;
                existingProfesor.Apellido = profesor.Apellido;
                existingProfesor.Dni = profesor.Dni;
                existingProfesor.FechaNacimiento = profesor.FechaNacimiento;
                existingProfesor.Cargo = profesor.Cargo;
                existingProfesor.UsuarioId = profesor.UsuarioId;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
