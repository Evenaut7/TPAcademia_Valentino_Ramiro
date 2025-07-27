using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading;

namespace API.Endpoints.Plan;

[ApiController]
[Route("/planes")]
public class UpdatePlan : EndpointBaseAsync
    .WithRequest<Models.Plan>
    .WithActionResult<Models.Plan>
{
    [HttpPut("{id}")]
    public override async Task<ActionResult<Models.Plan>> HandleAsync(
        [FromBody] Models.Plan request,
        CancellationToken cancellationToken = default)
    {
        int index = Models.Plan.Lista.FindIndex(p => p.Id == request.Id);
        if (index != -1)
        {
            Models.Plan.Lista[index] = request;
            return Ok(request);
        }
        else
        {
            return NotFound();
        }
    }
}
