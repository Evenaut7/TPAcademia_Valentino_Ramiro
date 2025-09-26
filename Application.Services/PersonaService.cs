using DTOs;
using Data;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class PersonaService
    {
        public PersonaDTO? Get(int id)
        {
            var personaRepository = new PersonaRepository();
            Persona? persona = personaRepository.Get(id);
            if (persona == null)
                return null;
            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                FechaNacimiento = persona.FechaNacimiento,
            };
        }

        public IEnumerable<PersonaDTO> GetAll()
        {
            var personaRepository = new PersonaRepository();
            var personas = personaRepository.GetAll();
            return personas.Select(persona => new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                FechaNacimiento = persona.FechaNacimiento,
            }).ToList();
        }

        public PersonaDTO Add(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();
            var persona = new Persona(
                id: dto.Id,
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                dni: dto.Dni,
                fechaNacimiento: dto.FechaNacimiento
            );
            personaRepository.Add(persona);
            dto.Id = persona.Id; // Asignar el Id generado al DTO
            return dto;
        }

        public bool Update(PersonaDTO dto)
        {
            var personaRepository = new PersonaRepository();
            var persona = new Persona(
                id: dto.Id,
                nombre: dto.Nombre,
                apellido: dto.Apellido,
                dni: dto.Dni,
                fechaNacimiento: dto.FechaNacimiento
            );
            return personaRepository.Update(persona);
        }

        public bool Delete(int id)
        {
            var personaRepository = new PersonaRepository();
            return personaRepository.Delete(id);
        }
    }
}
