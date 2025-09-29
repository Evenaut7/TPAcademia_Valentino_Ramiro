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
                Cargo = profesor.Cargo,
                UsuarioId = profesor.UsuarioId,
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
                Cargo = profesor.Cargo,
                UsuarioId = profesor.UsuarioId,
            }).ToList();
        }
        public ProfesorDTO Add(ProfesorDTO dto)
        {
            var profesorRepository = new ProfesorRepository();
            var profesor = new Profesor(
                id: dto.Id,
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                dni: dto.Dni,
                fechaNacimiento: dto.FechaNacimiento,
                Cargo: dto.Cargo,
                usuarioId: dto.UsuarioId
            );
            profesorRepository.Add(profesor);
            dto.Id = profesor.Id; // Asignar el Id generado al DTO
            return dto;
        }
        public bool Update(ProfesorDTO dto)
        {
            var profesorRepository = new ProfesorRepository();
            var profesor = profesorRepository.Get(dto.Id);
            if (profesor == null)
                return false;
            profesor.Nombre = dto.Nombre;
            profesor.Apellido = dto.Apellido;
            profesor.Dni = dto.Dni;
            profesor.FechaNacimiento = dto.FechaNacimiento;
            profesor.Cargo = dto.Cargo;
            profesor.UsuarioId = dto.UsuarioId;
            return profesorRepository.Update(profesor);
        }
        public bool Delete(int id)
        {
            var profesorRepository = new ProfesorRepository();
            return profesorRepository.Delete(id);
        }
    }
}
