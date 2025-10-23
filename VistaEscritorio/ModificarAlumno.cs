using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ModificarAlumno : Form
    {
        private AlumnoDTO alumno;

        public ModificarAlumno(AlumnoDTO alumnoAModificar)
        {
            InitializeComponent();
            alumno = alumnoAModificar;

            // Fill Alumno fields
            nombreTextBox.Text = alumno.Nombre;
            apellidoTextBox.Text = alumno.Apellido;
            dniTextBox.Text = alumno.Dni.ToString();
            fechaNacimientoPicker.Value = alumno.FechaNacimiento;
            legajoTextBox.Text = alumno.Legajo.ToString();
        }

        private async void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarAlumnoForm())
                {
                    return;
                }

                // Convertir DNI y Legajo a int
                if (!int.TryParse(dniTextBox.Text, out int dni))
                {
                    MessageBox.Show("El DNI debe ser un número válido.");
                    return;
                }

                if (!int.TryParse(legajoTextBox.Text, out int legajo))
                {
                    MessageBox.Show("El legajo debe ser un número válido.");
                    return;
                }

                // Actualizar campos de alumno con int
                alumno.Nombre = nombreTextBox.Text;
                alumno.Apellido = apellidoTextBox.Text;
                alumno.Dni = dni;
                alumno.FechaNacimiento = fechaNacimientoPicker.Value;
                alumno.Legajo = legajo;

                await AlumnoApiClient.UpdateAsync(alumno);
                MessageBox.Show("Datos modificados correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}");
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

            // Validar que DNI esté en rango válido (7-8 dígitos)
            if (!int.TryParse(dniTextBox.Text, out int dni) || dni < 1000000 || dni > 99999999)
            {
                MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.");
                return false;
            }

            // Validar que legajo sea positivo
            if (!int.TryParse(legajoTextBox.Text, out int legajo) || legajo <= 0)
            {
                MessageBox.Show("El legajo debe ser un número positivo.");
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

        private void ModificarAlumno_Load(object sender, EventArgs e)
        {
        }
    }
}