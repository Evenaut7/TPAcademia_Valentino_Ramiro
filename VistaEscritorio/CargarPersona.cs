using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class PersonaRegistrar : Form
    {
        public PersonaRegistrar()
        {
            InitializeComponent();
        }

        private async void registrarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarPersonaForm())
                {
                    return;
                }

                // Convertir DNI a int
                if (!int.TryParse(dniTextBox.Text, out int dni))
                {
                    MessageBox.Show("El DNI debe ser un número válido.");
                    return;
                }

                // Crear Persona
                var persona = new PersonaDTO
                {
                    Nombre = nombreTextBox.Text,
                    Apellido = apellidoTextBox.Text,
                    Dni = dni,
                    FechaNacimiento = fechaNacimientoPicker.Value
                };

                await PersonaApiClient.AddAsync(persona);
                MessageBox.Show("Persona registrada correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}");
            }
        }

        private bool ValidarPersonaForm()
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(apellidoTextBox.Text) ||
                string.IsNullOrWhiteSpace(dniTextBox.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return false;
            }

            // Validar solo letras en nombre y apellido
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombreTextBox.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras.");
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(apellidoTextBox.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$"))
            {
                MessageBox.Show("El apellido solo puede contener letras.");
                return false;
            }

            // Validar solo números en DNI
            if (!System.Text.RegularExpressions.Regex.IsMatch(dniTextBox.Text, @"^\d+$"))
            {
                MessageBox.Show("El DNI solo puede contener números.");
                return false;
            }

            // Validar que DNI esté en rango válido (7-8 dígitos)
            if (!int.TryParse(dniTextBox.Text, out int dni) || dni < 1000000 || dni > 99999999)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.");
                return false;
            }

            // Validar fecha de nacimiento no mayor a hoy
            if (fechaNacimientoPicker.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha actual.");
                return false;
            }

            return true;
        }

        private void fechaNacimientoLabel_Click(object sender, EventArgs e)
        {
        }

        private void PersonaRegistrar_Load(object sender, EventArgs e)
        {
        }

        private void nombreLabel_Click(object sender, EventArgs e)
        {
        }

        private void apellidoLabel_Click(object sender, EventArgs e)
        {
        }
    }
}