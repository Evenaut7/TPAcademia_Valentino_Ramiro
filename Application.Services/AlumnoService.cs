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
    public class AlumnoService
    {
        public AlumnoDTO? Get(int id)
        {
            var alumnoRepository = new AlumnoRepository();
            Alumno? alumno = alumnoRepository.Get(id);
            if (alumno == null)
                return null;
            return new AlumnoDTO
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                Dni = alumno.Dni,
                FechaNacimiento = alumno.FechaNacimiento,
                Legajo = alumno.Legajo,
                UsuarioId = alumno.UsuarioId,
            };
        }
        public IEnumerable<AlumnoDTO> GetAll()
        {
            var alumnoRepository = new AlumnoRepository();
            var alumnos = alumnoRepository.GetAll();
            return alumnos.Select(alumno => new AlumnoDTO
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                Dni = alumno.Dni,
                FechaNacimiento = alumno.FechaNacimiento,
                Legajo = alumno.Legajo,
                UsuarioId = alumno.UsuarioId,
            }).ToList();
        }
        public AlumnoDTO Add(AlumnoDTO dto)
        {
            var alumnoRepository = new AlumnoRepository();
            var alumno = new Alumno(
                id: dto.Id,
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                dni: dto.Dni,
                fechaNacimiento: dto.FechaNacimiento,
                legajo: dto.Legajo,
                usuarioId: dto.UsuarioId
            );
            alumnoRepository.Add(alumno);
            dto.Id = alumno.Id; // Asignar el Id generado al DTO
            return dto;
        }
        public bool Update(AlumnoDTO dto)
        {
            var alumnoRepository = new AlumnoRepository();
            var alumno = alumnoRepository.Get(dto.Id);
            if (alumno == null)
                return false;
            alumno.Nombre = dto.Nombre;
            alumno.Apellido = dto.Apellido;
            alumno.Dni = dto.Dni;
            alumno.FechaNacimiento = dto.FechaNacimiento;
            alumno.Legajo = dto.Legajo;
            alumno.UsuarioId = dto.UsuarioId;
            return alumnoRepository.Update(alumno);
        }
        public bool Delete(int id)
        {
            var alumnoRepository = new AlumnoRepository();
            return alumnoRepository.Delete(id);
        }
    }
}
