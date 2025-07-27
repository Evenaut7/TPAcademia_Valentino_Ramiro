using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading;

namespace API.Endpoints.Materia;
   
    [ApiController]
    [Route("/materias")]
    public class UpdateMateriaEndpoint : EndpointBaseAsync
            .WithRequest<Models.Materia>
            .WithActionResult<Models.Materia>
    {
        [HttpPut("{id}")]
        public override async Task<ActionResult<Models.Materia>> HandleAsync(
            [FromBody] Models.Materia request,
            CancellationToken cancellationToken = default)
        {
            int index = Models.Materia.Lista.FindIndex(a => a.Id == request.Id);
            if (index != -1)
            {
               Models.Materia.Lista[index] = request;
               return Ok(request);
            }
            else
            {
                return NotFound();
            }
    }
    }


