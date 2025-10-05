using API.Clients;
using DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ModificarUsuario : Form
    {
        private UsuarioDTO usuario;

        public ModificarUsuario(UsuarioDTO usuarioAModificar)
        {
            InitializeComponent();
            usuario = usuarioAModificar;
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

        private async void ModificarUsuario_Load(object sender, EventArgs e)
        {
            await CargarPersonasAsync();

            nombreUsuarioBox.Text = usuario.NombreUsuario;
            claveBox.Text = usuario.Clave;
            emailBox.Text = usuario.Email;
            privilegioBox.Text = usuario.Privilegio;
            habilitadoCheck.Checked = usuario.Habilitado;
            personaComboBox.SelectedValue = usuario.PersonaId;
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            usuario.NombreUsuario = nombreUsuarioBox.Text;
            usuario.Clave = claveBox.Text;
            usuario.Email = emailBox.Text;
            usuario.Privilegio = privilegioBox.Text;
            usuario.Habilitado = habilitadoCheck.Checked;
            usuario.PersonaId = (int)personaComboBox.SelectedValue;

            try
            {
                await UsuarioApiClient.UpdateAsync(usuario);
                MessageBox.Show("Usuario modificado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el usuario: {ex.Message}");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
