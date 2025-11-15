using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ModificarPersona : Form
    {
        private PersonaDTO persona;

        public ModificarPersona(PersonaDTO personaAModificar)
        {
            InitializeComponent();
            persona = personaAModificar;

            // Fill Persona fields
            nombreTextBox.Text = persona.Nombre;
            apellidoTextBox.Text = persona.Apellido;
            dniTextBox.Text = persona.Dni.ToString();
            fechaNacimientoPicker.Value = persona.FechaNacimiento;
        }

        private async void guardarButton_Click(object sender, EventArgs e)
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

                // Actualizar campos de persona
                persona.Nombre = nombreTextBox.Text;
                persona.Apellido = apellidoTextBox.Text;
                persona.Dni = dni;

                await PersonaApiClient.UpdateAsync(persona);
                MessageBox.Show("Datos modificados correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}");
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

            return true;
        }

        private void fechaNacimientoLabel_Click(object sender, EventArgs e)
        {
        }

        private void ModificarPersona_Load(object sender, EventArgs e)
        {
        }
    }
}