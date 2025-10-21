using BlazorServer.Components;
using API.Clients;

namespace BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddScoped<AlumnoApiClient>();
            builder.Services.AddScoped<MateriaApiClient>();
            builder.Services.AddScoped<PlanApiClient>();
            builder.Services.AddScoped<ComisionApiClient>();
            builder.Services.AddScoped<ProfesorApiClient>();
            builder.Services.AddScoped<CursoApiClient>();
            builder.Services.AddScoped<EspecialidadApiClient>();
            builder.Services.AddScoped<UsuarioApiClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}