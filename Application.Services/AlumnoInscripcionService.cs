using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class AlumnoInscripcionService
    {
        public AlumnoInscripcionDTO? Get(int id)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            var alumnoInscripcion = alumnoInscripcionRepository.Get(id);
            if (alumnoInscripcion == null)
                return null;
            return new AlumnoInscripcionDTO
            {
                Id = alumnoInscripcion.Id,
                Condicion = alumnoInscripcion.Condicion,
                Nota = alumnoInscripcion.Nota,
                CursoId = alumnoInscripcion.CursoId,
                UsuarioId = alumnoInscripcion.UsuarioId
            };
        }

        public IEnumerable<AlumnoInscripcionDTO> GetAll()
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            var inscripciones = alumnoInscripcionRepository.GetAll();
            return inscripciones.Select(ai => new AlumnoInscripcionDTO
            {
                Id = ai.Id,
                Condicion = ai.Condicion,
                Nota = ai.Nota,
                CursoId = ai.CursoId,
                UsuarioId = ai.UsuarioId
            });
        }

        public AlumnoInscripcionDTO Add(AlumnoInscripcionDTO dto)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();

            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion
            {
                Condicion = dto.Condicion,
                Nota = dto.Nota,
                CursoId = dto.CursoId,
                UsuarioId = dto.UsuarioId
            };

            alumnoInscripcionRepository.Add(alumnoInscripcion);

            dto.Id = alumnoInscripcion.Id;
            return dto;
        }

        public void Update(AlumnoInscripcionDTO dto)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            var existingAlumnoInscripcion = alumnoInscripcionRepository.Get(dto.Id);
            if (existingAlumnoInscripcion == null)
                throw new ArgumentException($"No se encontró una inscripción con ID {dto.Id} para actualizar.");

            existingAlumnoInscripcion.UsuarioId = dto.UsuarioId;
            existingAlumnoInscripcion.CursoId = dto.CursoId;
            existingAlumnoInscripcion.Condicion = dto.Condicion;
            existingAlumnoInscripcion.Nota = dto.Nota;

            if (!alumnoInscripcionRepository.Update(existingAlumnoInscripcion))
                throw new ArgumentException($"Error al actualizar la inscripción con ID {dto.Id}.");
        }

        public bool Delete(int id)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            var cursoRepository = new CursoRepository();

            // Obtener la inscripción
            var inscripcion = alumnoInscripcionRepository.Get(id);
            if (inscripcion == null)
                return false;

            // Obtener el curso y aumentar el cupo
            var curso = cursoRepository.Get(inscripcion.CursoId);
            if (curso != null)
            {
                curso.Cupo += 1;
                cursoRepository.Update(curso);
            }

            // Eliminar la inscripción
            return alumnoInscripcionRepository.Delete(id);
        }
    }
}
