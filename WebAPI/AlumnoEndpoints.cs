using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class AlumnoEndpoints
    {
        public static void MapAlumnoEndpints(this WebApplication app)
        {
            app.MapGet("/alumnos/{id}", (int id) =>
            {
                AlumnoService alumnoService = new AlumnoService();
                AlumnoDTO? dto = alumnoService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetAlumno")
            .Produces<AlumnoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/alumnos", () =>
            {
                AlumnoService alumnoService = new AlumnoService();
                var dtos = alumnoService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllAlumnos")
            .Produces<List<AlumnoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/alumnos", (AlumnoDTO dto) =>
            {
                try
                {
                    AlumnoService alumnoService = new AlumnoService();
                    AlumnoDTO alumnoDTO = alumnoService.Add(dto);
                    return Results.Created($"/alumnos/{alumnoDTO.Id}", alumnoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddAlumno")
            .Produces<AlumnoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/alumnos", (AlumnoDTO dto) =>
            {
                try
                {
                    AlumnoService alumnoService = new AlumnoService();

                    var updated = alumnoService.Update(dto);

                    if (!updated)
                    {
                        return Results.NotFound();
                    }
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateAlumno")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/alumnos/{id}", (int id) =>
            {
                AlumnoService alumnoService = new AlumnoService();
                var deleted = alumnoService.Delete(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
                .WithName("DeleteAlumno")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi();
        }
    }
}
