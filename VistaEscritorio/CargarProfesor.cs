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
            // Establecer fecha máxima como hoy
            fechaNacimientoPicker.MaxDate = DateTime.Today;
            // Establecer fecha por defecto (por ejemplo, hace 30 años)
            fechaNacimientoPicker.Value = DateTime.Today.AddYears(-30);
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void agregarProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarProfesorForm())
                {
                    return;
                }

                // Convertir DNI a int
                if (!int.TryParse(dniBox.Text, out int dni))
                {
                    MessageBox.Show("El DNI debe ser un número válido.");
                    return;
                }

                var nuevoProfesor = new DTOs.ProfesorDTO
                {
                    Nombre = nombreBox.Text,
                    Apellido = apellidoBox.Text,
                    Dni = dni,
                    FechaNacimiento = fechaNacimientoPicker.Value,
                    Cargo = cargoBox.Text,
                };

                await ProfesorApiClient.AddAsync(nuevoProfesor);
                MessageBox.Show("Profesor agregado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el profesor: {ex.Message}");
            }
        }

        private bool ValidarProfesorForm()
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(nombreBox.Text) ||
                string.IsNullOrWhiteSpace(apellidoBox.Text) ||
                string.IsNullOrWhiteSpace(dniBox.Text) ||
                string.IsNullOrWhiteSpace(cargoBox.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return false;
            }

            // Validar solo letras en nombre y apellido
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombreBox.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(apellidoBox.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$"))
            {
                MessageBox.Show("El apellido solo puede contener letras.");
                return false;
            }

            // Validar solo números en DNI
            if (!System.Text.RegularExpressions.Regex.IsMatch(dniBox.Text, @"^\d+$"))
            {
                MessageBox.Show("El DNI solo puede contener números.");
                return false;
            }

            // Validar que DNI esté en rango válido (7-8 dígitos)
            if (!int.TryParse(dniBox.Text, out int dni) || dni < 1000000 || dni > 99999999)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.");
                return false;
            }

            // Validar fecha de nacimiento
            if (fechaNacimientoPicker.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.");
                return false;
            }

            if (fechaNacimientoPicker.Value < new DateTime(1900, 1, 1))
            {
                MessageBox.Show("La fecha de nacimiento no puede ser anterior a 1900.");
                return false;
            }

            // Validar longitud del cargo
            if (cargoBox.Text.Length > 100)
            {
                MessageBox.Show("El cargo no puede superar los 100 caracteres.");
                return false;
            }

            return true;
        }
    }
}