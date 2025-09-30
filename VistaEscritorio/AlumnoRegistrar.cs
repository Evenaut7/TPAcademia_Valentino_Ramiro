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
    }
}
