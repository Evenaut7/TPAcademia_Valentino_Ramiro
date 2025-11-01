using DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Data;
using Domain.Model;

namespace Application.Services
{
    public class ProfesorCursoService
    {
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
                UsuarioId = profesorCurso.UsuarioId
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
                UsuarioId = pc.UsuarioId
            });
        }

        public ProfesorCursoDTO Add(ProfesorCursoDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();
            var profesorCursoRepository = new ProfesorCursoRepository();

            // Validar que el usuario existe
            var usuario = usuarioRepository.Get(dto.UsuarioId);
            if (usuario == null)
                throw new ArgumentException($"No existe un usuario con ID '{dto.UsuarioId}'.");

            // Validar que sea profesor
            if (usuario.Tipo != "Profesor")
                throw new ArgumentException($"Solo los profesores pueden dictar cursos. El usuario es de tipo '{usuario.Tipo}'.");

            // Validar que no exista otra asignación
            if (profesorCursoRepository.Exists(dto.UsuarioId, dto.CursoId))
                throw new ArgumentException($"El profesor con ID '{dto.UsuarioId}' ya está asignado al curso con ID '{dto.CursoId}'.");

            Domain.Model.ProfesorCurso profesorCurso = new Domain.Model.ProfesorCurso();
            profesorCurso.Cargo = dto.Cargo;
            profesorCurso.CursoId = dto.CursoId;
            profesorCurso.UsuarioId = dto.UsuarioId;

            profesorCursoRepository.Add(profesorCurso);
            dto.Id = profesorCurso.Id;
            return dto;
        }

        public void Update(ProfesorCursoDTO dto)
        {
            var profesorCursoRepository = new ProfesorCursoRepository();
            var existingProfesorCurso = profesorCursoRepository.Get(dto.Id);
            if (existingProfesorCurso == null)
                throw new ArgumentException($"No se encontró una asignación de profesor con ID {dto.Id} para actualizar.");

            existingProfesorCurso.Cargo = dto.Cargo;
            existingProfesorCurso.CursoId = dto.CursoId;
            existingProfesorCurso.UsuarioId = dto.UsuarioId;

            if (!profesorCursoRepository.Update(existingProfesorCurso))
                throw new ArgumentException($"Error al actualizar la asignación de profesor con ID {dto.Id}.");
        }

        public bool Delete(int id)
        {
            var profesorCursoRepository = new ProfesorCursoRepository();
            return profesorCursoRepository.Delete(id);
        }
    }
}
