using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Data;

namespace Application.Services
{
    public class ProfesorService
    {
        public ProfesorDTO? Get(int id)
        {
            var profesorRepository = new ProfesorRepository();
            Profesor? profesor = profesorRepository.Get(id);
            if (profesor == null)
                return null;
            return new ProfesorDTO
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Dni = profesor.Dni,
                FechaNacimiento = profesor.FechaNacimiento,
                Cargo = profesor.Cargo
            };
        }
        public IEnumerable<ProfesorDTO> GetAll()
        {
            var profesorRepository = new ProfesorRepository();
            var profesores = profesorRepository.GetAll();
            return profesores.Select(profesor => new ProfesorDTO
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Dni = profesor.Dni,
                FechaNacimiento = profesor.FechaNacimiento,
                Cargo = profesor.Cargo
            }).ToList();
        }
        public ProfesorDTO Add(ProfesorDTO dto)
        {
            var profesorRepository = new ProfesorRepository();
            var alumnoRepository = new AlumnoRepository();

            // Validación: DNI único en profesores
            if (profesorRepository.GetAll().Any(p => p.Dni == dto.Dni))
                throw new ArgumentException($"Ya existe un profesor con el DNI '{dto.Dni}'.");

            // Validación: DNI único en alumnos
            if (alumnoRepository.GetAll().Any(a => a.Dni == dto.Dni))
                throw new ArgumentException($"Ya existe un alumno con el DNI '{dto.Dni}'.");

            var profesor = new Profesor(
                id: dto.Id,
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                dni: dto.Dni,
                fechaNacimiento: dto.FechaNacimiento,
                cargo: dto.Cargo
            );
            profesorRepository.Add(profesor);
            dto.Id = profesor.Id; // Asignar el Id generado al DTO
            return dto;
        }
        public bool Update(ProfesorDTO dto)
        {
            var profesorRepository = new ProfesorRepository();
            var alumnoRepository = new AlumnoRepository();

            // Validación: DNI único en profesores (excluyendo el actual)
            if (profesorRepository.GetAll().Any(p => p.Dni == dto.Dni && p.Id != dto.Id))
                throw new ArgumentException($"Ya existe un profesor con el DNI '{dto.Dni}'.");

            // Validación: DNI único en alumnos
            if (alumnoRepository.GetAll().Any(a => a.Dni == dto.Dni))
                throw new ArgumentException($"Ya existe un alumno con el DNI '{dto.Dni}'.");

            var profesor = profesorRepository.Get(dto.Id);
            if (profesor == null)
                return false;
            profesor.Nombre = dto.Nombre;
            profesor.Apellido = dto.Apellido;
            profesor.Dni = dto.Dni;
            profesor.FechaNacimiento = dto.FechaNacimiento;
            profesor.Cargo = dto.Cargo;
            return profesorRepository.Update(profesor);
        }
        public bool Delete(int id)
        {
            var profesorRepository = new ProfesorRepository();
            return profesorRepository.Delete(id);
        }
    }
}
