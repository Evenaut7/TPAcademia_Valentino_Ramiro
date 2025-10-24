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
                Legajo = alumno.Legajo
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
                Legajo = alumno.Legajo
            }).ToList();
        }
        public AlumnoDTO Add(AlumnoDTO dto)
        {
            var alumnoRepository = new AlumnoRepository();
            var profesorRepository = new ProfesorRepository();

            // Validación: DNI único en alumnos
            if (alumnoRepository.GetAll().Any(a => a.Dni == dto.Dni))
                throw new ArgumentException($"Ya existe un alumno con el DNI '{dto.Dni}'.");

            // Validación: DNI único en profesores
            if (profesorRepository.GetAll().Any(p => p.Dni == dto.Dni))
                throw new ArgumentException($"Ya existe un profesor con el DNI '{dto.Dni}'.");

            // Validación: Legajo único en alumnos
            if (alumnoRepository.GetAll().Any(a => a.Legajo == dto.Legajo))
                throw new ArgumentException($"Ya existe un alumno con el legajo '{dto.Legajo}'.");

            var alumno = new Alumno(
                id: dto.Id,
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                dni: dto.Dni,
                fechaNacimiento: dto.FechaNacimiento,
                legajo: dto.Legajo
            );
            alumnoRepository.Add(alumno);
            dto.Id = alumno.Id; // Asignar el Id generado al DTO
            return dto;
        }
        public bool Update(AlumnoDTO dto)
        {
            var alumnoRepository = new AlumnoRepository();
            var profesorRepository = new ProfesorRepository();

            // Validación: DNI único en alumnos (excluyendo el actual)
            if (alumnoRepository.GetAll().Any(a => a.Dni == dto.Dni && a.Id != dto.Id))
                throw new ArgumentException($"Ya existe un alumno con el DNI '{dto.Dni}'.");

            // Validación: DNI único en profesores
            if (profesorRepository.GetAll().Any(p => p.Dni == dto.Dni))
                throw new ArgumentException($"Ya existe un profesor con el DNI '{dto.Dni}'.");

            // Validación: Legajo único en alumnos (excluyendo el actual)
            if (alumnoRepository.GetAll().Any(a => a.Legajo == dto.Legajo && a.Id != dto.Id))
                throw new ArgumentException($"Ya existe un alumno con el legajo '{dto.Legajo}'.");

            var alumno = alumnoRepository.Get(dto.Id);
            if (alumno == null)
                return false;
            alumno.Nombre = dto.Nombre;
            alumno.Apellido = dto.Apellido;
            alumno.Dni = dto.Dni;
            alumno.FechaNacimiento = dto.FechaNacimiento;
            alumno.Legajo = dto.Legajo;
            return alumnoRepository.Update(alumno);
        }
        public bool Delete(int id)
        {
            var alumnoRepository = new AlumnoRepository();
            return alumnoRepository.Delete(id);
        }

    }
}
