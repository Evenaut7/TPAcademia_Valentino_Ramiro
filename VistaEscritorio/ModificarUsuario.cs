using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ModificarUsuario : Form
    {
        private UsuarioDTO usuario;
        private List<PersonaDTO>? listaPersonas;

        public ModificarUsuario(UsuarioDTO usuarioAModificar)
        {
            InitializeComponent();
            usuario = usuarioAModificar;
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

        private async void ModificarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarPersonasAsync();

                nombreUsuarioBox.Text = usuario.NombreUsuario;
                claveBox.Text = "";
                emailBox.Text = usuario.Email;
                tipoBox.Text = usuario.Tipo;
                legajoBox.Text = usuario.Legajo ?? "";
                habilitadoCheck.Checked = usuario.Habilitado;

                if (personaComboBox.Items.Count > 0)
                    personaComboBox.SelectedValue = usuario.PersonaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}");
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                {
                    return;
                }

                usuario.NombreUsuario = nombreUsuarioBox.Text;
                usuario.Clave = claveBox.Text;
                usuario.Email = emailBox.Text;
                usuario.Tipo = tipoBox.Text;
                usuario.Legajo = string.IsNullOrWhiteSpace(legajoBox.Text) ? null : legajoBox.Text;
                usuario.Habilitado = habilitadoCheck.Checked;
                usuario.PersonaId = (int)personaComboBox.SelectedValue;

                await UsuarioApiClient.UpdateAsync(usuario);
                MessageBox.Show("Usuario modificado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el usuario: {ex.Message}");
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(nombreUsuarioBox.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailBox.Text))
            {
                MessageBox.Show("El email es obligatorio.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(claveBox.Text))
            {
                MessageBox.Show("La clave es obligatoria.");
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