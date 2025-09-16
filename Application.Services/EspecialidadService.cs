using DTOs;
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
    public class EspecialidadService
    {
        public EspecialidadDTO? Get(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            Especialidad? especialidad = especialidadRepository.Get(id);
            if (especialidad == null)
                return null;
            return new EspecialidadDTO
            {
                Id = especialidad.Id,
                Descripcion = especialidad.Descripcion
            };
        }
        public IEnumerable<EspecialidadDTO> GetAll()
        {
            var especialidadRepository = new EspecialidadRepository();
            var especialidades = especialidadRepository.GetAll();
            return especialidades.Select(e => new EspecialidadDTO
            {
                Id = e.Id,
                Descripcion = e.Descripcion
            }).ToList();
        }
        public EspecialidadDTO Add(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();
            Especialidad especialidad = new Especialidad();
            especialidad.Descripcion = dto.Descripcion;
            especialidadRepository.Add(especialidad);
            dto.Id = especialidad.Id;
            return dto;
        }
        public bool delete(int id)
        {
            var especialidadRepository = new EspecialidadRepository();
            return especialidadRepository.Delete(id);
        }
        public bool Update(EspecialidadDTO dto)
        {
            var especialidadRepository = new EspecialidadRepository();
            Especialidad especialidad = new Especialidad();
            especialidad.Id = dto.Id;
            especialidad.Descripcion = dto.Descripcion;
            return especialidadRepository.Update(especialidad);
        }
    }
}
