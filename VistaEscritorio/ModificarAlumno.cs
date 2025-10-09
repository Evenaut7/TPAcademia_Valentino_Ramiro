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
            legajoTextBox.Text = alumno.Legajo;

        }

        private async void guardarButton_Click(object sender, EventArgs e)
        {
            // Validar campos de alumno
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text) ||
                string.IsNullOrWhiteSpace(apellidoTextBox.Text) ||
                string.IsNullOrWhiteSpace(dniTextBox.Text) ||
                string.IsNullOrWhiteSpace(legajoTextBox.Text))
            {
                MessageBox.Show("Debe completar los campos obligatorios del alumno.");
                return;
            }

            // Actualizar campos de alumno
            alumno.Nombre = nombreTextBox.Text;
            alumno.Apellido = apellidoTextBox.Text;
            alumno.Dni = dniTextBox.Text;
            alumno.FechaNacimiento = fechaNacimientoPicker.Value;
            alumno.Legajo = legajoTextBox.Text;

            try
            {
                await AlumnoApiClient.UpdateAsync(alumno);

                MessageBox.Show("Datos modificados correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}");
            }
        }

        private void fechaNacimientoLabel_Click(object sender, EventArgs e)
        {

        }

        private void ModificarAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}