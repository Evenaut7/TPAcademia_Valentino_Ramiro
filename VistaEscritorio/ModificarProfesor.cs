using API.Clients; // Asumo ProfesorApiClient y UsuarioApiClient
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ModificarProfesor : Form
    {
        private ProfesorDTO profesor;

        public ModificarProfesor(ProfesorDTO profesorAModificar)
        {
            InitializeComponent();
            profesor = profesorAModificar;

            nombreBox.Text = profesor.Nombre;
            apellidoBox.Text = profesor.Apellido;
            dniBox.Text = profesor.Dni.ToString();

            cargoBox.Text = profesor.Cargo;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void modificarProfesorButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreBox.Text) || string.IsNullOrWhiteSpace(apellidoBox.Text) ||
               string.IsNullOrWhiteSpace(dniBox.Text) || string.IsNullOrWhiteSpace(cargoBox.Text))
            {
                MessageBox.Show("Debe ingresar todos los datos.");
                return;
            }
            if (!int.TryParse(dniBox.Text, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número entero.");
                return;
            }

            profesor.Nombre = nombreBox.Text;
            profesor.Apellido = apellidoBox.Text;
            profesor.Dni = dniBox.Text;

            profesor.Cargo = cargoBox.Text;

            try
            {
                await ProfesorApiClient.UpdateAsync(profesor);
                MessageBox.Show("Profesor modificado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el profesor: {ex.Message}");
            }
        }
    }
}