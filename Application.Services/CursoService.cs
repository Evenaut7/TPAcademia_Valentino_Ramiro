using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CursoService
    {
        public CursoDTO Get(int id)
        {
            var cursoRepository = new Data.CursoRepository();
            var curso = cursoRepository.Get(id);

            if (curso == null)
            return null;

            return new CursoDTO
            {
                Id = curso.Id,
                AnioCalendario = curso.AnioCalendario,
                Cupo = curso.Cupo,
                MateriaId = curso.MateriaId,
                ComisionId = curso.ComisionId
            };
        }

        public IEnumerable<CursoDTO> GetAll()
        {
            var cursoRepository = new Data.CursoRepository();
            var cursos = cursoRepository.GetAll();
            return cursos.Select(curso => new CursoDTO
            {
                Id = curso.Id,
                AnioCalendario = curso.AnioCalendario,
                Cupo = curso.Cupo,
                MateriaId = curso.MateriaId,
                ComisionId = curso.ComisionId
            }).ToList();
        }

        public CursoDTO Add(CursoDTO dto)
        {
            var cursoRepository = new Data.CursoRepository();
            using var context = new Data.TPIContext();

            // Obtener la materia y la comisión desde la base de datos
            var materia = context.Materias.Find(dto.MateriaId);
            var comision = context.Comisiones.Find(dto.ComisionId);

            if (materia == null)
                throw new ArgumentException("La materia especificada no existe.");
            if (comision == null)
                throw new ArgumentException("La comisión especificada no existe.");

            // Validar que ambos pertenezcan al mismo plan
            if (materia.PlanId != comision.PlanId)
                throw new ArgumentException("La materia y la comisión deben pertenecer al mismo plan.");

            if (cursoRepository.Exists(dto.AnioCalendario, dto.MateriaId, dto.ComisionId))
                throw new ArgumentException("Ya existe un curso con la misma materia, comisión y año calendario.");

            var curso = new Curso(0, dto.AnioCalendario, dto.Cupo, dto.MateriaId, dto.ComisionId);
            cursoRepository.Add(curso);
            dto.Id = curso.Id;
            return dto;
        }

        public bool Update(CursoDTO dto)
        {
            var cursoRepository = new Data.CursoRepository();
            if (cursoRepository.Exists(dto.AnioCalendario, dto.MateriaId, dto.ComisionId, dto.Id))
                throw new ArgumentException("Ya existe un curso con la misma materia, comisión y año calendario.");
            var existingCurso = cursoRepository.Get(dto.Id);
            if (existingCurso == null)
                return false;
            existingCurso.AnioCalendario = dto.AnioCalendario;
            existingCurso.Cupo = dto.Cupo;
            existingCurso.MateriaId = dto.MateriaId;
            existingCurso.ComisionId = dto.ComisionId;
            // Asumiendo que el repositorio tiene un método Update
            cursoRepository.Update(existingCurso);
            return true;
        }

        public bool Delete(int id)
        {
            var cursoRepository = new Data.CursoRepository();
            return cursoRepository.Delete(id);
        }

        public IEnumerable<CursoDTO> Buscar(string? comision, string? materia)
        {
            var cursoRepository = new Data.CursoRepository();
            var cursos = cursoRepository.Buscar(comision, materia);

            return cursos.Select(curso => new CursoDTO
            {
                Id = curso.Id,
                AnioCalendario = curso.AnioCalendario,
                Cupo = curso.Cupo,
                MateriaId = curso.MateriaId,
                ComisionId = curso.ComisionId
            }).ToList();
        }
    }
}
