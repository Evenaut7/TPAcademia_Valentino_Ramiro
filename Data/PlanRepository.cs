using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PlanRepository
    {
        public void Add(Plan plan)
        {
            using var context = CreateContext();
            context.Planes.Add(plan);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var plan = context.Planes.Find(id);
            if (plan != null)
            {
                context.Planes.Remove(plan);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Plan? Get(int id)
        {
            using var context = CreateContext();
            return context.Planes
                .FirstOrDefault(c => c.Id == id);
        }
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }
        public IEnumerable<Plan> GetAll()
        {
            using var context = CreateContext();
            return context.Planes.OrderBy(p => p.Descripcion).ToList();
        }
        public bool DescripcionExists(string desc, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Planes.Where(c => c.Descripcion.ToLower() == desc.ToLower());
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return query.Any();
        }
        public bool Update(Plan plan)
        {
            using var context = CreateContext();
            var existingPlan = context.Planes.Find(plan.Id);
            if (existingPlan != null)
            {
                existingPlan.Descripcion = plan.Descripcion;

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}