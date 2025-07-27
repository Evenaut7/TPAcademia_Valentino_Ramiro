using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading;

namespace API.Endpoints.Plan;

public class DeletePlanRequest
{
    public int Id { get; set; }
}

[ApiController]
[Route("/planes")]
public class DeletePlan : EndpointBaseAsync
    .WithRequest<DeletePlanRequest>
    .WithActionResult
{
    [HttpDelete("{id}")]
    public override async Task<ActionResult> HandleAsync(
        [FromRoute] DeletePlanRequest request,
        CancellationToken cancellationToken = default)
    {
        var planToDelete = Models.Plan.Lista.Find(p => p.Id == request.Id);
        if (planToDelete is not null)
        {
            Models.Plan.Lista.Remove(planToDelete);
            return Ok(planToDelete);
        }
        else
        {
            return NotFound();
        }
    }
}
