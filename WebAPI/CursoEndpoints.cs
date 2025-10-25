using Application.Services;
using DTOs;
namespace WebAPI
{
    public static class CursoEndpoints
    {
        public static void MapCursoEndpoints(this WebApplication app)
        {
            app.MapGet("/cursos/{id}", (int id) =>
            {
                CursoService cursoService = new CursoService();
                CursoDTO? dto = cursoService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetCurso")
            .Produces<CursoDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/cursos", () =>
            {
                CursoService cursoService = new CursoService();
                var dtos = cursoService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllCursos")
            .Produces<List<CursoDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/cursos", (CursoDTO dto) =>
            {
                try
                {
                    CursoService cursoService = new CursoService();
                    CursoDTO cursoDTO = cursoService.Add(dto);
                    return Results.Created($"/cursos/{cursoDTO.Id}", cursoDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddCurso")
            .Produces<CursoDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/cursos/{id}", (int id, CursoDTO dto) =>
            {
                if (id != dto.Id)
                {
                    return Results.BadRequest(new { error = "El ID de la URL no coincide con el ID del cuerpo." });
                }
                try
                {
                    CursoService cursoService = new CursoService();
                    bool updated = cursoService.Update(dto);
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
                .WithName("UpdateCurso")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi();

            app.MapDelete("/cursos/{id}", (int id) =>
            {
                CursoService cursoService = new CursoService();
                bool deleted = cursoService.Delete(id);
                if (!deleted)
                {
                    return Results.NotFound();
                }
                return Results.NoContent();
            })
                .WithName("DeleteCurso")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi();

            app.MapGet("/cursos/buscar", (string? comision, string? materia) =>
            {
                CursoService cursoService = new CursoService();
                var resultados = cursoService.Buscar(comision, materia);
                return Results.Ok(resultados);
            })
                .WithName("BuscarCursos")
                .Produces<List<CursoDTO>>(StatusCodes.Status200OK)
                .WithOpenApi();
        }
    }
}
