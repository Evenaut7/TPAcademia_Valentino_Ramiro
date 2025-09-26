using System;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ModificarAlumno : Form
    {
        private UsuarioDTO alumno;

        public ModificarAlumno(UsuarioDTO alumnoSeleccionado)
        {
            InitializeComponent();
            alumno = alumnoSeleccionado;
            CargarDatos();
        }

        private void CargarDatos()
        {
            // Asume que tienes controles como nombreTextBox, emailTextBox, etc.
            nombreTextBox.Text = alumno.Nombre;
            apellidoTextBox.Text = alumno.Apellido;
            emailTextBox.Text = alumno.Email;
            alumnoTextBox.Text = alumno.NombreUsuario;
            claveTextBox.Text = alumno.Clave;
            // Agrega los demás campos según corresponda
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            alumno.Nombre = nombreTextBox.Text;
            alumno.Apellido = apellidoTextBox.Text;
            alumno.Email = emailTextBox.Text;
            alumno.NombreUsuario = alumnoTextBox.Text;
            alumno.Clave = claveTextBox.Text;
            // Agrega los demás campos según corresponda

            try
            {
                await UsuarioApiClient.UpdateAsync(alumno);
                MessageBox.Show("Alumno modificado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el alumno: {ex.Message}");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}