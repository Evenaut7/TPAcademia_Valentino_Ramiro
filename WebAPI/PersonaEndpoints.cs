using DTOs;
using Application.Services;
namespace WebAPI
{
    public static class PersonaEndpoints
    {
        public static void MapPersonaEndpoints(this WebApplication app)
        {
            app.MapGet("/personas/{id}", (int id) =>
            {
                PersonaService personaService = new PersonaService();
                PersonaDTO? dto = personaService.Get(id);
                if (dto == null)
                {
                    return Results.NotFound(new { error = "La persona no existe." });
                }
                return Results.Ok(dto);
            })
            .WithName("GetPersona")
            .Produces<PersonaDTO>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();

            app.MapGet("/personas", () =>
            {
                PersonaService personaService = new PersonaService();
                var dtos = personaService.GetAll();
                return Results.Ok(dtos);
            })
            .WithName("GetAllPersonas")
            .Produces<List<PersonaDTO>>(StatusCodes.Status200OK)
            .WithOpenApi();

            app.MapPost("/personas", (PersonaDTO dto) =>
            {
                try
                {
                    PersonaService personaService = new PersonaService();
                    var (success, message, data) = personaService.Add(dto);

                    if (!success)
                    {
                        return Results.BadRequest(new { error = message });
                    }

                    return Results.Created($"/personas/{data.Id}", data);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("AddPersona")
            .Produces<PersonaDTO>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapPut("/personas/{id}", (int id, PersonaDTO dto) =>
            {
                try
                {
                    if (id != dto.Id)
                    {
                        return Results.BadRequest(new { error = "El ID de la URL no coincide con el ID del cuerpo." });
                    }

                    PersonaService personaService = new PersonaService();
                    var (success, message) = personaService.Update(dto);

                    if (!success)
                    {
                        return Results.BadRequest(new { error = message });
                    }

                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("UpdatePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi();

            app.MapDelete("/personas/{id}", (int id) =>
            {
                PersonaService personaService = new PersonaService();
                var (success, message) = personaService.Delete(id);

                if (!success)
                {
                    return Results.NotFound(new { error = message });
                }

                return Results.NoContent();
            })
            .WithName("DeletePersona")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi();
        }
    }
}