using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading;

namespace API.Endpoints.Plan;

[ApiController]
[Route("/planes")]
public class GetPlanById : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<Models.Plan>
{
    [HttpGet("{id}")]
    public override async Task<ActionResult<Models.Plan>> HandleAsync(
        [FromRoute] int id,
        CancellationToken cancellationToken = default)
    {
        var plan = Models.Plan.Lista.FirstOrDefault(p => p.Id == id);
        return plan is not null ? Ok(plan) : NotFound();
    }
}
