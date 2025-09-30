using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class ProfesorEndpoints
    {
        public static void MapProfesorEndpoints(this WebApplication app)
        {
            app.MapGet("/profesores/{id}", (int id) =>
            {
                ProfesorService profesorService = new ProfesorService();
                ProfesorDTO? dto = profesorService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetProfesor")
            .Produces<ProfesorDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/profesores", () =>
            {
                ProfesorService profesorService = new ProfesorService();
                var dtos = profesorService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllProfesores")
            .Produces<List<ProfesorDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/profesores", (ProfesorDTO dto) =>
            {
                try
                {
                    ProfesorService profesorService = new ProfesorService();
                    ProfesorDTO profesorDTO = profesorService.Add(dto);
                    return Results.Created($"/profesores/{profesorDTO.Id}", profesorDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddProfesor")
            .Produces<ProfesorDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/profesores", (ProfesorDTO dto) =>
            {
                try
                {
                    ProfesorService profesorService = new ProfesorService();
                    var updated = profesorService.Update(dto);
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
            .WithName("UpdateProfesor")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/profesores/{id}", (int id) =>
            {
                ProfesorService profesorService = new ProfesorService();
                var deleted = profesorService.Delete(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
            .WithName("DeleteProfesor")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}