using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTOs;
using Domain.Model;

namespace Application.Services
{
    public class ComisionService
    {
        public ComisionDTO? Get(int id)
        {
            var comisionRepository = new ComisionRepository();
            Comision? comision = comisionRepository.Get(id);

            if (comision == null)
                return null;

            return new ComisionDTO
            {
                Id = comision.Id,
                Nombre = comision.Nombre,
                AnioEspecialidad = comision.AnioEspecialidad,
                PlanId = comision.PlanId
            };
        }

        public IEnumerable<ComisionDTO> GetAll()
        {
            var comisionRepository = new ComisionRepository();
            var comisiones = comisionRepository.GetAll();

            return comisiones.Select(c => new ComisionDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                AnioEspecialidad = c.AnioEspecialidad,
                PlanId = c.PlanId
            }).ToList();
        }

        public ComisionDTO Add(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();
            // Validar que no exista otra comisión con el mismo nombre
            if (comisionRepository.NombreExists(dto.Nombre))
            {
                throw new ArgumentException($"Ya existe una comisión con el nombre '{dto.Nombre}'.");
            }
            Comision comision = new Comision(0, dto.Nombre, dto.AnioEspecialidad, dto.PlanId);
            comisionRepository.Add(comision);
            dto.Id = comision.Id;
            return dto;
        }

        public void Update(ComisionDTO dto)
        {
            var comisionRepository = new ComisionRepository();
            // Validar que no exista otra comisión con el mismo nombre (excluyendo la comisión actual)
            if (comisionRepository.NombreExists(dto.Nombre, dto.Id))
            {
                throw new ArgumentException($"Ya existe una comisión con el nombre '{dto.Nombre}'.");
            }
            Comision comision = new Comision(dto.Id, dto.Nombre, dto.AnioEspecialidad, dto.PlanId);
            if (!comisionRepository.Update(comision))
            {
                throw new ArgumentException($"No se encontró una comisión con ID {dto.Id} para actualizar.");
            }
        }

        public bool Delete(int id)
        {
            var comisionRepository = new ComisionRepository();
            return comisionRepository.Delete(id);
        }
    }
}
