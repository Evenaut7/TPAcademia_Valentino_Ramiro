using System;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ModificarUsuario : Form
    {
        private UsuarioDTO usuario;

        public ModificarUsuario(UsuarioDTO usuarioSeleccionado)
        {
            InitializeComponent();
            usuario = usuarioSeleccionado;
            CargarDatos();
        }

        private void CargarDatos()
        {
            emailTextBox.Text = usuario.Email;
            usuarioTextBox.Text = usuario.NombreUsuario;
            claveTextBox.Text = usuario.Clave;
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            usuario.Email = emailTextBox.Text;
            usuario.NombreUsuario = usuarioTextBox.Text;
            usuario.Clave = claveTextBox.Text;

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
