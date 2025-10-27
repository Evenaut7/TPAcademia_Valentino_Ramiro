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
        public AlumnoInscripcionDTO Add(AlumnoInscripcionDTO dto)
        {
            var usuarioRepository = new UsuarioRepository();
            var comisionRepository = new ComisionRepository();
            var cursoRepository = new CursoRepository();
            var usuario = usuarioRepository.GetByAlumnoId(dto.AlumnoId);
            var curso = cursoRepository.Get(dto.CursoId);
            var comision = comisionRepository.Get(curso.ComisionId);

            if (usuario.PlanId != comision.PlanId)
                throw new ArgumentException("No puedes inscribirte en cursos fuera de tu plan.");

            if (curso.Cupo <= 0)
                throw new ArgumentException("No hay cupo disponible para este curso.");

            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            if (alumnoInscripcionRepository.Exists(dto.AlumnoId, dto.CursoId))
            {
                throw new ArgumentException($"El alumno con ID '{dto.AlumnoId}' ya está inscrito en el curso con ID '{dto.CursoId}'.");
            }

            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion
            {
                Condicion = dto.Condicion,
                Nota = dto.Nota,
                CursoId = dto.CursoId,
                AlumnoId = dto.AlumnoId
            };

            alumnoInscripcionRepository.Add(alumnoInscripcion);

            // Reduce cupo
            curso.Cupo -= 1;
            cursoRepository.Update(curso);

            dto.Id = alumnoInscripcion.Id;
            return dto;
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
                AlumnoId = alumnoInscripcion.AlumnoId
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
                AlumnoId = ai.AlumnoId
            });
        }

        public bool Update(AlumnoInscripcionDTO dto)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            var existingAlumnoInscripcion = alumnoInscripcionRepository.Get(dto.Id);
            if (existingAlumnoInscripcion != null)
            {
                existingAlumnoInscripcion.AlumnoId = dto.AlumnoId;
                existingAlumnoInscripcion.CursoId = dto.CursoId;
                existingAlumnoInscripcion.Condicion = dto.Condicion;
                existingAlumnoInscripcion.Nota = dto.Nota;
                return alumnoInscripcionRepository.Update(existingAlumnoInscripcion);
            }
            return false;
        }

    }
}
