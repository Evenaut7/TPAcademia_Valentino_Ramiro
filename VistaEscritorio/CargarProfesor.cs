using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class CargarProfesor : Form
    {
        public CargarProfesor()
        {
            InitializeComponent();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void agregarProfesor_Click(object sender, EventArgs e)
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

            var nuevoProfesor = new DTOs.ProfesorDTO
            {
                Nombre = nombreBox.Text,
                Apellido = apellidoBox.Text,
                Dni = dniBox.Text,

                Cargo = cargoBox.Text,
            };

            try
            {
                await ProfesorApiClient.AddAsync(nuevoProfesor);
                MessageBox.Show("Profesor agregado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el profesor: {ex.Message}");
            }
        }
    }
}