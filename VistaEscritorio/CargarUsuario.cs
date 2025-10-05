using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class CargarUsuario : Form
    {
        public CargarUsuario()
        {
            InitializeComponent();
        }

        private async Task CargarPersonasAsync()
        {
            var alumnos = await AlumnoApiClient.GetAllAsync();
            var profesores = await ProfesorApiClient.GetAllAsync();

            var lista = alumnos.Select(a => new { a.Id, Nombre = a.Nombre + " (Alumno)" })
                .Concat(profesores.Select(p => new { p.Id, Nombre = p.Nombre + " (Profesor)" }))
                .ToList();

            personaComboBox.DataSource = lista;
            personaComboBox.DisplayMember = "Nombre";
            personaComboBox.ValueMember = "Id";
        }

        private async void CargarUsuario_Load(object sender, EventArgs e)
        {
            await CargarPersonasAsync();
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuarioBox.Text) ||
                string.IsNullOrWhiteSpace(claveBox.Text) ||
                string.IsNullOrWhiteSpace(emailBox.Text))
            {
                MessageBox.Show("Debe ingresar todos los datos.");
                return;
            }

            var nuevoUsuario = new UsuarioDTO
            {
                NombreUsuario = nombreUsuarioBox.Text,
                Clave = claveBox.Text,
                Email = emailBox.Text,
                Privilegio = privilegioBox.Text,
                Habilitado = habilitadoCheck.Checked,
                PersonaId = (int)personaComboBox.SelectedValue
            };

            try
            {
                await UsuarioApiClient.AddAsync(nuevoUsuario);
                MessageBox.Show("Usuario agregado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
