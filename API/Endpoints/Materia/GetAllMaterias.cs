using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Endpoints.Alumno
{
    [ApiController]
    [Route("/materias")]
    public class GetAllMaterias : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<List<Models.Materia>>
    {
        [HttpGet("/materias")]
        public override async Task<ActionResult<List<Models.Materia>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return Ok(Models.Materia.Lista);
        }
    }
}
