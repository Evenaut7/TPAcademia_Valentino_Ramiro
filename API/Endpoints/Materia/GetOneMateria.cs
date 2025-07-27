using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading;

namespace API.Endpoints.Materia;

[ApiController]
[Route("/materias")]
public class GetMateriaById : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<Models.Materia>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<Models.Materia>> HandleAsync(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var materia = Models.Materia.Lista.FirstOrDefault(m => m.Id == id);
        return materia is not null ? Ok(materia) : NotFound();
    }
}
