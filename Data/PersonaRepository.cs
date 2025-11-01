using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PersonaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Persona persona)
        {
            using var context = CreateContext();
            context.Personas.Add(persona);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Persona? Get(int id)
        {
            using var context = CreateContext();
            return context.Personas.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Persona> GetAll()
        {
            using var context = CreateContext();
            return context.Personas.ToList();
        }

        public bool Update(Persona persona)
        {
            using var context = CreateContext();
            var existingPersona = context.Personas.Find(persona.Id);
            if (existingPersona != null)
            {
                existingPersona.Nombre = persona.Nombre;
                existingPersona.Apellido = persona.Apellido;
                existingPersona.Dni = persona.Dni;
                existingPersona.FechaNacimiento = persona.FechaNacimiento;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DniExists(long dni, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Personas.Where(p => p.Dni == dni);
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }
            return query.Any();
        }

        public Persona? GetByDni(long dni)
        {
            using var context = CreateContext();
            return context.Personas.FirstOrDefault(p => p.Dni == dni);
        }
    }
}
