using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ApiAcademia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Materia>> GetMaterias()
        {
            return Ok(Materia.Lista);
        }

        [HttpGet("{id}")]
        public ActionResult<Materia> GetMateria(int id)
        {
            var materia = Materia.Lista.Find(m => m.Id == id);
            if (materia != null)
            {
                return Ok(materia);
            }
            return NotFound();
        }
        
        [HttpPost]
        public ActionResult<Materia> CreateMateria([FromBody] Materia materia)
        {
            if (materia == null)
            {
                return BadRequest("Materia cannot be null");
            }
            materia.Id = Materia.ObtenerProximoId();
            Materia.Lista.Add(materia);
            return CreatedAtAction(nameof(GetMateria), new { id = materia.Id }, materia);
        }

        [HttpPut("{id}")]
        public ActionResult<Materia> UpdateMateria(int id, [FromBody] Materia materia)
        {
            if (materia == null || materia.Id != id)
            {
                return BadRequest("Invalid materia data");
            }
            int index = Materia.Lista.FindIndex(m => m.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            Materia.Lista[index] = materia;
            return Ok(materia);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMateria(int id)
        {
            var materia = Materia.Lista.Find(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }
            Materia.Lista.Remove(materia);
            return NoContent();
        }
    }
}
