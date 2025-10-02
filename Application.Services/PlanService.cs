    using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class PlanService
    {
        public PlanDTO Add(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            // Validar que no exista otro plan con la misma descripción
            if (planRepository.DescripcionExists(dto.Descripcion))
            {
                throw new ArgumentException($"Ya existe un plan con la descripción '{dto.Descripcion}'.");
            }

            Plan plan = new Plan();
            //plan.Id = 0;
            plan.Descripcion = dto.Descripcion;
            plan.EspecialidadId = dto.EspecialidadId;

            planRepository.Add(plan);

            dto.Id = plan.Id;
            return dto;
        }

        public bool Delete(int id)
        {
            var planRepository = new PlanRepository();
            return planRepository.Delete(id);
        }

        public PlanDTO? Get(int id)
        {
            var planRepository = new PlanRepository();
            Plan? plan = planRepository.Get(id);

            if (plan == null)
                return null;

            return new PlanDTO
            {
                Id = plan.Id,
                Descripcion = plan.Descripcion,
                EspecialidadId = plan.EspecialidadId 
            };
        }

        public IEnumerable<PlanDTO> GetAll()
        {
            var planRepository = new PlanRepository();
            var planes = planRepository.GetAll();

            return planes.Select(p => new PlanDTO
            {
                Id = p.Id,
                Descripcion = p.Descripcion,
                EspecialidadId = p.EspecialidadId
            }).ToList();
        }

        public bool Update(PlanDTO dto)
        {
            var planRepository = new PlanRepository();

            // Validar duplicado de descripción (excluyendo el plan actual)
            if (planRepository.DescripcionExists(dto.Descripcion, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro plan con la descripción '{dto.Descripcion}'.");
            }

            Plan plan = new Plan();
            plan.Id = dto.Id;
            plan.EspecialidadId = dto.EspecialidadId;
            plan.Descripcion = dto.Descripcion;

            return planRepository.Update(plan);


        }
    }
}
