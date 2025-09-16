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
    }
}
