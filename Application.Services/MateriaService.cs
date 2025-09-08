using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class MateriaService
    {

        public MateriaDTO? Get(int id)
        {
            var materiaRepository = new MateriaRepository();
            Materia? materia = materiaRepository.Get(id);

            if (materia == null)
                return null;

            return new MateriaDTO
            {
                Id = materia.Id,
                Descripcion = materia.Descripcion,
                HsSemanales = materia.HsSemanales,
                HsTotales = materia.HsTotales,
                PlanId = materia.PlanId
            };
        }

        public IEnumerable<MateriaDTO> GetAll()
        {
            var materiaRepository = new MateriaRepository();
            var materias = materiaRepository.GetAll();

            return materias.Select(m => new MateriaDTO
            {
                Id = m.Id,
                Descripcion = m.Descripcion,
                HsSemanales = m.HsSemanales,
                HsTotales = m.HsTotales,
                PlanId = m.PlanId
            }).ToList();
        }

        public MateriaDTO Add(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            // Validar que no exista otra materia con la misma descripción en el mismo plan
            if (materiaRepository.DescripcionExists(dto.Descripcion))
            {
                throw new ArgumentException($"Ya existe una materia con la descripción '{dto.Descripcion}' en este plan.");
            }

            Materia materia = new Materia(0, dto.Descripcion, dto.HsSemanales, dto.HsTotales, dto.PlanId);

            materiaRepository.Add(materia);

            dto.Id = materia.Id;
            return dto;
        }

        public bool Update(MateriaDTO dto)
        {
            var materiaRepository = new MateriaRepository();

            // Validar que no exista duplicado de descripción en el mismo plan (excluyendo la materia actual)
            if (materiaRepository.DescripcionExists(dto.Descripcion, dto.PlanId))
            {
                throw new ArgumentException($"Ya existe otra materia con la descripción '{dto.Descripcion}' en este plan.");
            }

            Materia materia = new Materia(dto.Id, dto.Descripcion, dto.HsSemanales, dto.HsTotales, dto.PlanId);

            return materiaRepository.Update(materia);
        }

        public bool Delete(int id)
        {
            var materiaRepository = new MateriaRepository();
            return materiaRepository.Delete(id);
        }
    }
}
