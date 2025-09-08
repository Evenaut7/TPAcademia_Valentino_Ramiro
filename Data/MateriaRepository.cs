using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{ 
    public class MateriaRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Materia materia)
        {
            using var context = CreateContext();
            context.Materias.Add(materia);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var materia = context.Materias.Find(id);
            if (materia != null)
            {
                context.Materias.Remove(materia);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Materia? Get(int id)
        {
            using var context = CreateContext();
            return context.Materias
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Materia> GetAll()
        {
            using var context = CreateContext();
            return context.Materias
                .ToList();
        }

        public bool DescripcionExists(string desc, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Materias.Where(c => c.Descripcion.ToLower() == desc.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return query.Any();
        }

        public bool Update(Materia materia)
        {
            using var context = CreateContext();
            var existingMateria = context.Materias.Find(materia.Id);
            if (existingMateria != null)
            {
                existingMateria.Descripcion= materia.Descripcion;

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
