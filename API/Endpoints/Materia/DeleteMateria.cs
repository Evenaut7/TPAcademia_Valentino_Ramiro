using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading;

namespace API.Endpoints.Materia;

public class DeleteMateriaRequest
{
    public int Id { get; set; }
}

[ApiController]
[Route("/materias")]
public class DeleteMateria : EndpointBaseAsync
    .WithRequest<DeleteMateriaRequest>
    .WithActionResult
{
    [HttpDelete("{id}")]
    public override async Task<ActionResult> HandleAsync(
        [FromRoute] DeleteMateriaRequest request,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine(request.Id);
        var materiaToDelete = Models.Materia.Lista.Find(a => a.Id == request.Id);
        if (materiaToDelete is Models.Materia)
        {
            Models.Materia.Lista.Remove(materiaToDelete);
            return Ok(materiaToDelete);
        }
        else
        {
            return NotFound();
        }
    }
}
