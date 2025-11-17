using API.Clients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Auth.WindowsForms;
using Application.Services;

namespace VistaEscritorio
{
    internal static class Program
    {
        private static IServiceProvider _serviceProvider;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Capturar errores globales en la UI
            System.Windows.Forms.Application.ThreadException += Application_ThreadException;

            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            var authService = new WindowsFormsAuthService();
            AuthServiceProvider.Register(authService);

            while (true)
            {
                if (!await authService.IsAuthenticatedAsync())
                {
                    var loginForm = _serviceProvider.GetRequiredService<Inicio>();
                    if (loginForm.ShowDialog() != DialogResult.OK)
                        return; // usuario canceló login
                }

                try
                {
                    var abmMenu = _serviceProvider.GetRequiredService<ABMMenu>();
                    await abmMenu.CargarDatosUsuarioAsync();
                    // Application.Run debe ejecutarse en el hilo principal STA
                    System.Windows.Forms.Application.Run(abmMenu);
                    break;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message, "Sesión Expirada",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Registrar servicios y formularios
            services.AddSingleton<UsuarioService>();
            services.AddTransient<Inicio>();    // login
            services.AddTransient<ABMMenu>();   // menú principal
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is UnauthorizedAccessException)
            {
                MessageBox.Show("Su sesión ha expirado. Debe volver a autenticarse.",
                    "Sesión Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reiniciar la aplicación para volver al login
                System.Windows.Forms.Application.Restart();
            }
            else
            {
                MessageBox.Show($"Error inesperado: {e.Exception.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}