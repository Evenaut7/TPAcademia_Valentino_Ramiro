using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpLogging(o => { });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorWasm",
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:7170", "http://localhost:5124")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            builder.Services.AddDbContext<Data.TPIContext>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpLogging();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowBlazorWasm");

            app.MapMateriaEndpoints();
            app.MapPlanEndpoints();
            app.MapUsuarioEndpoints();
            app.MapEspecialidadEndpoints();
            app.MapComisionEndpoints();
            app.MapCursoEndpoints();
            app.MapAlumnoEndpints();
            app.MapProfesorEndpoints();
            app.MapAlumnoInscripcionEndpoints();
            app.MapProfesorCursoEndpoints();
            app.MapAuthEndpoints();


            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Data.TPIContext>();
                context.Database.EnsureCreated();

                // Verifica si la persona existe, si no, la crea
                if (!context.Personas.Any(p => p.Id == -10))
                {
                    var persona = new Domain.Model.Persona
                    {
                        Id = -10,
                        Nombre = "Juan",
                        Apellido = "Perez",
                        Dni = "12345678",
                        FechaNacimiento = new DateTime(2000, 1, 1)
                    };

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Personas ON");
                        context.Personas.Add(persona);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Personas OFF");
                        transaction.Commit();
                    }
                }

                // Verifica si el usuario admin existe, si no, lo crea
                if (!context.Usuarios.Any(u => u.NombreUsuario == "admin"))
                {
                    var admin = new Domain.Model.Usuario();
                    admin.Id = -1; // Asigna el id deseado
                    admin.NombreUsuario = "admin";
                    admin.Email = "admin@correo.com";
                    admin.SetClave("1234");
                    admin.Habilitado = true;
                    admin.Privilegio = "Administrador";
                    admin.PersonaId = -10;

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Usuarios ON");
                        context.Usuarios.Add(admin);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Usuarios OFF");
                        transaction.Commit();
                    }
                }
            }

            app.Run();

        }
    }
}
