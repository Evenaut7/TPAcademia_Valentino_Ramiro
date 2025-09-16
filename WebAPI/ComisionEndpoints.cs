using DTOs;
using Application.Services;

namespace WebAPI
{
    public static class ComisionEndpoints
    {
        public static void MapComisionEndpoints(this WebApplication app)
        {
            app.MapGet("/comisiones/{id}", (int id) =>
            {
                ComisionService comisionService = new ComisionService();
                ComisionDTO? dto = comisionService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(dto);
            })
            .WithName("GetComision")
            .Produces<ComisionDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/comisiones", () =>
            {
                ComisionService comisionService = new ComisionService();
                var dtos = comisionService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllComisiones")
            .Produces<List<ComisionDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/comisiones", (ComisionDTO dto) =>
            {
                try
                {
                    ComisionService comisionService = new ComisionService();
                    ComisionDTO comisionDTO = comisionService.Add(dto);
                    return Results.Created($"/comisiones/{comisionDTO.Id}", comisionDTO);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddComision")
            .Produces<ComisionDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/comisiones/{id}", (int id, ComisionDTO dto) =>
            {
                if (id != dto.Id)
                {
                    return Results.BadRequest(new { error = "El ID de la URL no coincide con el ID del cuerpo." });
                }
                try
                {
                    ComisionService comisionService = new ComisionService();
                    comisionService.Update(dto);
                    return Results.NoContent();
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdateComision")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/comisiones/{id}", (int id) =>
            {
                ComisionService comisionService = new ComisionService();
                bool deleted = comisionService.Delete(id);
                if (deleted)
                {
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound();
                }
            }
            )
                .WithName("DeleteComision")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
                .WithOpenApi();
        }

    }
}
