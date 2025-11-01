using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Data;
using DTOs;
namespace Application.Services
{
    public class PersonaService
    {
        public PersonaDTO? Get(int id)
        {
            var personaRepository = new PersonaRepository();
            var persona = personaRepository.Get(id);

            if (persona == null)
                return null;

            return new PersonaDTO
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Dni = persona.Dni,
                FechaNacimiento = persona.FechaNacimiento
            };
        }

        public IEnumerable<PersonaDTO> GetAll()
        {
            var personaRepository = new PersonaRepository();
            var personas = personaRepository.GetAll();

            return personas.Select(p => new PersonaDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Dni = p.Dni,
                FechaNacimiento = p.FechaNacimiento
            }).ToList();
        }

        public (bool success, string message, PersonaDTO? data) Add(PersonaDTO dto)
        {
            try
            {
                var personaRepository = new PersonaRepository();

                if (personaRepository.DniExists(dto.Dni))
                    return (false, $"Ya existe una persona con el DNI '{dto.Dni}'.", null);

                if (string.IsNullOrWhiteSpace(dto.Nombre))
                    return (false, "El nombre no puede estar vacío.", null);

                if (string.IsNullOrWhiteSpace(dto.Apellido))
                    return (false, "El apellido no puede estar vacío.", null);

                if (dto.FechaNacimiento == default(DateTime))
                    return (false, "La fecha de nacimiento es obligatoria.", null);

                if (dto.FechaNacimiento > DateTime.Today)
                    return (false, "La fecha de nacimiento no puede ser en el futuro.", null);

                var persona = new Persona
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Dni = dto.Dni,
                    FechaNacimiento = dto.FechaNacimiento
                };

                personaRepository.Add(persona);

                dto.Id = persona.Id;
                return (true, "Persona creada exitosamente.", dto);
            }
            catch (Exception ex)
            {
                return (false, $"Error inesperado: {ex.Message}", null);
            }
        }

        public (bool success, string message) Update(PersonaDTO dto)
        {
            try
            {
                var personaRepository = new PersonaRepository();

                var personaExistente = personaRepository.Get(dto.Id);
                if (personaExistente == null)
                    return (false, "La persona no existe.");

                if (personaRepository.DniExists(dto.Dni, excludeId: dto.Id))
                    return (false, $"Ya existe otra persona con el DNI '{dto.Dni}'.");

                if (string.IsNullOrWhiteSpace(dto.Nombre))
                    return (false, "El nombre no puede estar vacío.");

                if (string.IsNullOrWhiteSpace(dto.Apellido))
                    return (false, "El apellido no puede estar vacío.");

                if (dto.FechaNacimiento == default(DateTime))
                    return (false, "La fecha de nacimiento es obligatoria.");

                if (dto.FechaNacimiento > DateTime.Today)
                    return (false, "La fecha de nacimiento no puede ser en el futuro.");

                var persona = new Persona
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Dni = dto.Dni,
                    FechaNacimiento = dto.FechaNacimiento
                };

                personaRepository.Update(persona);
                return (true, "Persona actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error inesperado: {ex.Message}");
            }
        }

        public (bool success, string message) Delete(int id)
        {
            try
            {
                var personaRepository = new PersonaRepository();

                if (!personaRepository.Delete(id))
                    return (false, "La persona no existe.");

                return (true, "Persona eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
    }
}