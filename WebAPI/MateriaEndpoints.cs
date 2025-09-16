using DTOs;
using Application.Services;

namespace WebAPI
{
    public static class MateriaEndpoints
    {
        public static void MapMateriaEndpoints(this WebApplication app)
        {
            app.MapGet("/materias/{id}", (int id) =>
            {
                MateriaService materiaService = new MateriaService();

                MateriaDTO? dto = materiaService.Get(id);

                if (dto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(dto);
            })
            .WithName("GetMateria")
            .Produces<MateriaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/materias", () =>
            {
                MateriaService materiaService = new MateriaService();

                var dtos = materiaService.GetAll();

                return Results.Ok(dtos);
            })
            .WithName("GetAllMaterias")
            .Produces<List<MateriaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();


            app.MapPost("/materias", (MateriaDTO dto) =>
            {
                try
                {
                    MateriaService materiaService = new MateriaService();

                    MateriaDTO materiaDTO = materiaService.Add(dto);

                    return Results.Created($"/materias/{materiaDTO.Id}", materiaDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddMateria")
            .Produces<MateriaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();



            app.MapPut("/materias", (MateriaDTO dto) =>
            {
                try
                {
                    MateriaService materiaService = new MateriaService();

                    var updated = materiaService.Update(dto);

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
            .WithName("UpdateMateria")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();


            app.MapDelete("/materias/{id}", (int id) =>
            {
                MateriaService materiaService = new MateriaService();

                var deleted = materiaService.Delete(id);

                if (!deleted)
                {
                    return Results.NotFound();
                }

                return Results.NoContent();
            })
            .WithName("DeleteMateria")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

        }
    }
}