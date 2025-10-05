using DTOs;
using Application.Services;

namespace WebAPI
{
    public static class AlumnoInscripcionEndpoints
    {
        public static void MapAlumnoInscripcionEndpoints(this WebApplication app)
        {
            app.MapGet("/alumnosInscripciones/{id}", (int id) =>
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                AlumnoInscripcionDTO? dto = alumnoInscripcionService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetAlumnoInscripcion")
            .Produces<AlumnoInscripcionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/alumnosInscripciones", () =>
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                var dtos = alumnoInscripcionService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllAlumnosInscripciones")
            .Produces<List<AlumnoInscripcionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/alumnosInscripciones", (AlumnoInscripcionDTO dto) =>
            {
                try
                {
                    AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                    AlumnoInscripcionDTO alumnoInscripcionDTO = alumnoInscripcionService.Add(dto);
                    return Results.Created($"/alumnosInscripciones/{alumnoInscripcionDTO.Id}", alumnoInscripcionDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddAlumnosInscripciones")
            .Produces<AlumnoInscripcionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/alumnosInscripciones/{id}", (int id, AlumnoInscripcionDTO dto) =>
            {
                if (id != dto.Id)
                {
                    return Results.BadRequest(new { error = "El ID de la URL no coincide con el ID del cuerpo." });
                }
                try
                {
                    AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                    alumnoInscripcionService.Update(dto);
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateAlumnosInscripciones")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/alumnosInscripciones/{id}", (int id) =>
            {
                AlumnoInscripcionService alumnoInscripcionService = new AlumnoInscripcionService();
                bool deleted = alumnoInscripcionService.Delete(id);
                if (deleted)
                {
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound();
                }
            })
            .WithName("DeleteAlumnoInscripcion")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
