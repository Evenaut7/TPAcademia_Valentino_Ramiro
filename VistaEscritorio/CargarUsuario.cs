using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class CargarUsuario : Form
    {
        private List<PersonaDTO>? listaPersonas;

        public CargarUsuario()
        {
            InitializeComponent();
        }

        private async Task CargarPersonasAsync()
        {
            var personas = await PersonaApiClient.GetAllAsync();
            listaPersonas = personas?.ToList();

            var lista = listaPersonas
                .Select(p => new { p.Id, p.Nombre, p.Apellido })
                .ToList();

            personaComboBox.DataSource = lista;
            personaComboBox.DisplayMember = "Nombre";
            personaComboBox.ValueMember = "Id";
        }

        private async void CargarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarPersonasAsync();
                tipoBox.Text = "Alumno";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}");
            }
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                {
                    return;
                }

                var nuevoUsuario = new UsuarioDTO
                {
                    NombreUsuario = nombreUsuarioBox.Text,
                    Clave = claveBox.Text,
                    Email = emailBox.Text,
                    Tipo = tipoBox.Text,
                    Legajo = string.IsNullOrWhiteSpace(legajoBox.Text) ? null : legajoBox.Text,
                    Habilitado = habilitadoCheck.Checked,
                    PersonaId = (int)personaComboBox.SelectedValue
                };

                await UsuarioApiClient.AddAsync(nuevoUsuario);
                MessageBox.Show("Usuario agregado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}");
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(nombreUsuarioBox.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(claveBox.Text))
            {
                MessageBox.Show("La clave es obligatoria.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailBox.Text))
            {
                MessageBox.Show("El email es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tipoBox.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de usuario.");
                return false;
            }

            if (personaComboBox.SelectedValue == null || (int)personaComboBox.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar una persona.");
                return false;
            }

            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}