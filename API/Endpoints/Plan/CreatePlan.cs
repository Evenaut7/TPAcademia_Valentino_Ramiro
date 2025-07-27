using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading;

namespace API.Endpoints.Plan;

[ApiController]
[Route("/planes")]
public class CreatePlan : EndpointBaseAsync
    .WithRequest<Models.Plan>
    .WithActionResult<Models.Plan>
{
    [HttpPost]
    public override async Task<ActionResult<Models.Plan>> HandleAsync(
        [FromBody] Models.Plan request,
        CancellationToken cancellationToken = default)
    {
        request.Id = Models.Plan.ObtenerProximoId();
        Models.Plan.Lista.Add(request);
        return Created($"/planes/{request.Id}", request);
    }
}

