using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading;

namespace API.Endpoints.Plan;

[ApiController]
[Route("/planes")]
public class GetAllPlanes : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<List<Models.Plan>>
{
    [HttpGet]
    public override async Task<ActionResult<List<Models.Plan>>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        return Ok(Models.Plan.Lista);
    }
}
