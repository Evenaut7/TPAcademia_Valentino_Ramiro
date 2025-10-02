using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Data
{
    public class ProfesorCursoRepository
    {
        private TPIContext CreateContext()
        {
            return new TPIContext();
        }

        public void Add(ProfesorCurso profesorCurso)
        {
            using var context = CreateContext();
            context.ProfesoresCursos.Add(profesorCurso);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            using var context = CreateContext();
            var profesorCurso = context.ProfesoresCursos.Find(id);
            if (profesorCurso != null)
            {
                context.ProfesoresCursos.Remove(profesorCurso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public ProfesorCurso? Get(int id)
        {
            using var context = CreateContext();
            return context.ProfesoresCursos
                .Include(pc => pc.Profesor)
                .Include(pc => pc.Curso)
                .FirstOrDefault(pc => pc.Id == id);
        }

        public IEnumerable<ProfesorCurso> GetAll()
        {
            using var context = CreateContext();
            return context.ProfesoresCursos
                .Include(pc => pc.Profesor)
                .Include(pc => pc.Curso)
                .ToList();
        }

        public bool Update(ProfesorCurso profesorCurso)
        {
            using var context = CreateContext();
            var existingProfesorCurso = context.ProfesoresCursos.Find(profesorCurso.Id);
            if (existingProfesorCurso != null)
            {
                existingProfesorCurso.Cargo = profesorCurso.Cargo;
                existingProfesorCurso.CursoId = profesorCurso.CursoId;
                existingProfesorCurso.ProfesorId = profesorCurso.ProfesorId;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Exists(int profesorId, int cursoId)
        {
            using var context = CreateContext();
            return context.ProfesoresCursos
                .Any(pc => pc.ProfesorId == profesorId && pc.CursoId == cursoId);
        }

    }
}
