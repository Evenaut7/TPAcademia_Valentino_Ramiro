using DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Data;

namespace Application.Services
{
    public class ProfesorCursoService
    {
        public ProfesorCursoDTO Add(ProfesorCursoDTO dto)
        {
            var profesorCursoRepository = new ProfesorCursoRepository();
            // Validar que no exista otra inscripción para el mismo alumno y curso
            if (profesorCursoRepository.Exists(dto.ProfesorId, dto.CursoId))
            {
                throw new ArgumentException($"El profesor con ID '{dto.ProfesorId}' ya está asignado al curso con ID '{dto.CursoId}'.");
            }
            Domain.Model.ProfesorCurso profesorCurso = new Domain.Model.ProfesorCurso();
            profesorCurso.Cargo = dto.Cargo;
            profesorCurso.CursoId = dto.CursoId;
            profesorCurso.ProfesorId = dto.ProfesorId;
            profesorCursoRepository.Add(profesorCurso);
            dto.Id = profesorCurso.Id;
            return dto;
        }

        public bool Delete(int id)
        {
            var profesorCursoRepository = new ProfesorCursoRepository();
            return profesorCursoRepository.Delete(id);
        }

        public ProfesorCursoDTO? Get(int id)
        {
            var profesorCursoRepository = new ProfesorCursoRepository();
            var profesorCurso = profesorCursoRepository.Get(id);
            if (profesorCurso == null)
                return null;
            return new ProfesorCursoDTO
            {
                Id = profesorCurso.Id,
                Cargo = profesorCurso.Cargo,
                CursoId = profesorCurso.CursoId,
                ProfesorId = profesorCurso.ProfesorId
            };
        }

        public IEnumerable<ProfesorCursoDTO> GetAll()
        {
            var profesorCursoRepository = new ProfesorCursoRepository();
            var profesorCursos = profesorCursoRepository.GetAll();
            return profesorCursos.Select(pc => new ProfesorCursoDTO
            {
                Id = pc.Id,
                Cargo = pc.Cargo,
                CursoId = pc.CursoId,
                ProfesorId = pc.ProfesorId
            });
        }

        public bool Update(ProfesorCursoDTO dto)
        {
            var profesorCursoRepository = new ProfesorCursoRepository();
            var existingProfesorCurso = profesorCursoRepository.Get(dto.Id);
            if (existingProfesorCurso == null)
            {
                return false;
            }
            existingProfesorCurso.Cargo = dto.Cargo;
            existingProfesorCurso.CursoId = dto.CursoId;
            existingProfesorCurso.ProfesorId = dto.ProfesorId;
            return profesorCursoRepository.Update(existingProfesorCurso);
        }
    }
}
