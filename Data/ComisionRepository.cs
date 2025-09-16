using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ComisionRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Comision comision)
        {
            using var context = CreateContext();
            context.Set<Comision>().Add(comision);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var comision = context.Set<Comision>().Find(id);
            if (comision != null)
            {
                context.Set<Comision>().Remove(comision);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Comision? Get(int id)
        {
            using var context = CreateContext();
            return context.Set<Comision>()
                .Include(c => c.Plan)
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Comision> GetAll()
        {
            using var context = CreateContext();
            return context.Set<Comision>()
                .Include(c => c.Plan)
                .ToList();
        }

        public bool NombreExists(string nombre, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Set<Comision>().Where(c => c.Nombre.ToLower() == nombre.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return query.Any();
        }

        public bool Update(Comision comision)
        {
            using var context = CreateContext();
            var existingComision = context.Set<Comision>().Find(comision.Id);
            if (existingComision != null)
            {
                existingComision.Nombre = comision.Nombre;
                existingComision.AnioEspecialidad = comision.AnioEspecialidad;
                existingComision.PlanId = comision.PlanId;

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}