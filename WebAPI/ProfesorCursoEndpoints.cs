using DTOs;
using Application.Services;

namespace WebAPI
{
    public static class ProfesorCursoEndpoints
    {
        public static void MapProfesorCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/profesoresCursos/{id}", (int id) =>
            {
                ProfesorCursoService profesorCursoService = new ProfesorCursoService();
                ProfesorCursoDTO? dto = profesorCursoService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetProfesorCurso")
            .Produces<ProfesorCursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/profesoresCursos", () =>
            {
                ProfesorCursoService profesorCursoService = new ProfesorCursoService();
                var dtos = profesorCursoService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllProfesoresCursos")
            .Produces<List<ProfesorCursoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/profesoresCursos", (ProfesorCursoDTO dto) =>
            {
                try
                {
                    ProfesorCursoService profesorCursoService = new ProfesorCursoService();
                    ProfesorCursoDTO profesorCursoDTO = profesorCursoService.Add(dto);
                    return Results.Created($"/profesoresCursos/{profesorCursoDTO.Id}", profesorCursoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddProfesorCurso")
            .Produces<ProfesorCursoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/profesoresCursos/{id}", (int id, ProfesorCursoDTO dto) =>
            {
                if (id != dto.Id)
                {
                    return Results.BadRequest(new { error = "El ID de la URL no coincide con el ID del cuerpo." });
                }
                try
                {
                    ProfesorCursoService profesorCursoService = new ProfesorCursoService();
                    profesorCursoService.Update(dto);
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateProfesorCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/profesoresCursos/{id}", (int id) =>
            {
                ProfesorCursoService profesorCursoService = new ProfesorCursoService();
                bool deleted = profesorCursoService.Delete(id);
                if (deleted)
                {
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound();
                }
            })
            .WithName("DeleteProfesorCurso")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}
