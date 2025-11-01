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
            var usuarioRepository = new UsuarioRepository();
            var comisionRepository = new ComisionRepository();
            var cursoRepository = new CursoRepository();
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();

            // Validar que el usuario existe
            var usuario = usuarioRepository.Get(dto.UsuarioId);
            if (usuario == null)
                throw new ArgumentException($"No existe un usuario con ID '{dto.UsuarioId}'.");

            // Validar que sea alumno
            if (usuario.Tipo != "Alumno")
                throw new ArgumentException($"Solo los alumnos pueden inscribirse a materias. El usuario es de tipo '{usuario.Tipo}'.");

            // Validar que el curso existe
            var curso = cursoRepository.Get(dto.CursoId);
            if (curso == null)
                throw new ArgumentException($"No existe un curso con ID '{dto.CursoId}'.");

            // Validar comisión y plan
            var comision = comisionRepository.Get(curso.ComisionId);
            if (comision == null)
                throw new ArgumentException("La comisión del curso no existe.");

            if (usuario.PlanId != comision.PlanId)
                throw new ArgumentException("No puedes inscribirte en cursos fuera de tu plan.");

            // Validar cupo
            if (curso.Cupo <= 0)
                throw new ArgumentException("No hay cupo disponible para este curso.");

            // Validar que no exista otra inscripción
            if (alumnoInscripcionRepository.Exists(dto.UsuarioId, dto.CursoId))
                throw new ArgumentException($"El usuario con ID '{dto.UsuarioId}' ya está inscrito en el curso con ID '{dto.CursoId}'.");

            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion
            {
                Condicion = dto.Condicion,
                Nota = dto.Nota,
                CursoId = dto.CursoId,
                UsuarioId = dto.UsuarioId
            };

            alumnoInscripcionRepository.Add(alumnoInscripcion);

            // Reduce cupo
            curso.Cupo -= 1;
            cursoRepository.Update(curso);

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
