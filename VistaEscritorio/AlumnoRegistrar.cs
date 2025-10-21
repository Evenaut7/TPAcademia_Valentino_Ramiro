using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class AlumnoRegistrar : Form
    {
        public AlumnoRegistrar()
        {
            InitializeComponent();
        }

        private async void registrarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarAlumnoForm())
                {
                    return;
                }

                // Solo crear Alumno
                var alumno = new AlumnoDTO
                {
                    Nombre = nombreTextBox.Text,
                    Apellido = apellidoTextBox.Text,
                    Dni = dniTextBox.Text,
                    FechaNacimiento = fechaNacimientoPicker.Value,
                    Legajo = legajoTextBox.Text
                };
                await AlumnoApiClient.AddAsync(alumno);

                MessageBox.Show("Alumno registrado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}");
            }
        }

        private bool ValidarAlumnoForm()
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(apellidoTextBox.Text) ||
                string.IsNullOrWhiteSpace(dniTextBox.Text) ||
                string.IsNullOrWhiteSpace(legajoTextBox.Text))
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

            // Validar solo números en DNI y Legajo
            if (!System.Text.RegularExpressions.Regex.IsMatch(dniTextBox.Text, @"^\d+$"))
            {
                MessageBox.Show("El DNI solo puede contener números.");
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(legajoTextBox.Text, @"^\d+$"))
            {
                MessageBox.Show("El legajo solo puede contener números.");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fechaNacimientoLabel_Click(object sender, EventArgs e)
        {

        }

        private void AlumnoRegistrar_Load_1(object sender, EventArgs e)
        {

        }

        private void legajoLabel_Click(object sender, EventArgs e)
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
