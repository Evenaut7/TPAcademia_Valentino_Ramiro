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

            // Fill Usuario fields
            if (alumno.Usuario != null)
            {
                usuarioTextBox.Text = alumno.Usuario.NombreUsuario;
                claveTextBox.Text = alumno.Usuario.Clave;
                emailTextBox.Text = alumno.Usuario.Email;
                privilegioComboBox.Text = alumno.Usuario.Privilegio;
            }
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

                // Si los campos de usuario están completos, crear o actualizar usuario
                if (!string.IsNullOrWhiteSpace(usuarioTextBox.Text) &&
                    !string.IsNullOrWhiteSpace(claveTextBox.Text) &&
                    !string.IsNullOrWhiteSpace(emailTextBox.Text) &&
                    !string.IsNullOrWhiteSpace(privilegioComboBox.Text))
                {
                    if (alumno.Usuario == null)
                    {
                        // Crear usuario nuevo
                        var usuario = new UsuarioDTO
                        {
                            NombreUsuario = usuarioTextBox.Text,
                            Clave = claveTextBox.Text,
                            Email = emailTextBox.Text,
                            Privilegio = privilegioComboBox.Text,
                            Habilitado = true,
                            PersonaId = alumno.Id
                        };
                        await UsuarioApiClient.AddAsync(usuario);
                        alumno.UsuarioId = usuario.Id;
                        await AlumnoApiClient.UpdateAsync(alumno);
                    }
                    else
                    {
                        // Actualizar usuario existente
                        alumno.Usuario.NombreUsuario = usuarioTextBox.Text;
                        alumno.Usuario.Clave = claveTextBox.Text;
                        alumno.Usuario.Email = emailTextBox.Text;
                        alumno.Usuario.Privilegio = privilegioComboBox.Text;
                        alumno.Usuario.Habilitado = true;
                        await UsuarioApiClient.UpdateAsync(alumno.Usuario);
                    }
                }

                MessageBox.Show("Datos modificados correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}");
            }
        }
    }
}