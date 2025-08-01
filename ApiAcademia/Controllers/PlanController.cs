using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ApiAcademia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Plan>> GetPlanes()
        {
            return Ok(Plan.Lista);
        }

        [HttpGet("{id}")]
        public ActionResult<Plan> GetPlan(int id)
        {
            var materia = Plan.Lista.Find(m => m.Id == id);
            if (materia != null)
            {
                return Ok(materia);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Plan> CreatePlan([FromBody] Plan plan)
        {
            if (plan == null)
            {
                return BadRequest("Materia cannot be null");
            }
            plan.Id = Plan.ObtenerProximoId();
            Plan.Lista.Add(plan);
            return CreatedAtAction(nameof(GetPlan), new { id = plan.Id }, plan);
        }

        [HttpPut("{id}")]
        public ActionResult<Plan> UpdatePlan(int id, [FromBody] Plan plan)
        {
            if (plan == null || plan.Id != id)
            {
                return BadRequest("Invalid materia data");
            }
            int index = Plan.Lista.FindIndex(m => m.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            Plan.Lista[index] = plan;
            return Ok(plan);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlan(int id)
        {
            var plan = Plan.Lista.Find(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }
            Plan.Lista.Remove(plan);
            return NoContent();
        }
    }
}
