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
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
            if (alumnoInscripcionRepository.Exists(dto.AlumnoId, dto.CursoId))
            {
                throw new ArgumentException($"El alumno con ID '{dto.AlumnoId}' ya está inscrito en el curso con ID '{dto.CursoId}'.");
            }
            Domain.Model.AlumnoInscripcion alumnoInscripcion = new Domain.Model.AlumnoInscripcion();
            
            alumnoInscripcion.Condicion = dto.Condicion;
            alumnoInscripcion.Nota = dto.Nota;
            alumnoInscripcion.CursoId = dto.CursoId;
            alumnoInscripcion.AlumnoId = dto.AlumnoId;
            alumnoInscripcionRepository.Add(alumnoInscripcion);
            dto.Id = alumnoInscripcion.Id;
            return dto;
        }
        
        public bool Delete(int id)
        {
            var alumnoInscripcionRepository = new AlumnoInscripcionRepository();
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
