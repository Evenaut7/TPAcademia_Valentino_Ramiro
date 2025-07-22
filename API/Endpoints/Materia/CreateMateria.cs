using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Reflection;

namespace API.Endpoints.Materia;

    [ApiController]
    [Route("/materias")]
public class CreateMateria : EndpointBaseAsync
    .WithRequest<Models.Materia>
    .WithActionResult<Models.Materia>
{
    [HttpPost]  
    public override async Task<ActionResult<Models.Materia>> HandleAsync(
        [FromBody] Models.Materia request,
        CancellationToken cancellationToken = default)
    {
        request.Id = Models.Materia.ObtenerProximoId();
        Models.Materia.Lista.Add(request);
        return Created($"/materias/{request.Id}", request);
    }
}