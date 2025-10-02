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

            app.Run();

        }
    }
}
