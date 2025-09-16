using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(Curso curso)
        {
            using var context = CreateContext();
            context.Cursos.Add(curso);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var curso = context.Cursos.Find(id);
            if (curso != null)
            {
                context.Cursos.Remove(curso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Curso? Get(int id)
        {
            using var context = CreateContext();
            return context.Cursos
                .Include(c => c.Materia)
                .Include(c => c.Comision)
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Curso> GetAll()
        {
            using var context = CreateContext();
            return context.Cursos
                .Include(c => c.Materia)
                .Include(c => c.Comision)
                .ToList();
        }

        public bool Exists(int anioCalendario, int materiaId, int comisionId, int? excludeId = null)
        {
            using var context = CreateContext();
            var query = context.Cursos.Where(c =>
                c.AnioCalendario == anioCalendario &&
                c.MateriaId == materiaId &&
                c.ComisionId == comisionId
            );
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }
            return query.Any();
        }

        public bool Update(Curso curso)
        {
            using var context = CreateContext();
            var existingCurso = context.Cursos.Find(curso.Id);
            if (existingCurso != null)
            {
                existingCurso.AnioCalendario = curso.AnioCalendario;
                existingCurso.Cupo = curso.Cupo;
                existingCurso.MateriaId = curso.MateriaId;
                existingCurso.ComisionId = curso.ComisionId;

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}