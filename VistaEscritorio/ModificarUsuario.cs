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
        private List<PlanDTO>? listaPlanes;

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
                .Select(p => new { p.Id, NombreCompleto = $"{p.Apellido}, {p.Nombre}" })
                .ToList();

            personaComboBox.DataSource = lista;
            personaComboBox.DisplayMember = "NombreCompleto";
            personaComboBox.ValueMember = "Id";
        }

        private async Task CargarPlanesAsync()
        {
            var planes = await PlanApiClient.GetAllAsync();
            listaPlanes = planes?.ToList();

            // Cargar especialidades para mostrar el nombre en lugar del año
            var especialidades = await EspecialidadApiClient.GetAllAsync();
            var listaEspecialidades = especialidades?.ToList();

            // Agregar opción "Sin asignar" al inicio
            var lista = new List<object> { new { Id = 0, Descripcion = "(Sin plan asignado)" } };
            lista.AddRange(listaPlanes.Select(p => new
            {
                p.Id,
                Descripcion = $"{p.Descripcion} - {listaEspecialidades?.FirstOrDefault(e => e.Id == p.EspecialidadId)?.Descripcion ?? "Especialidad no encontrada"}"
            }));

            planComboBox.DataSource = lista;
            planComboBox.DisplayMember = "Descripcion";
            planComboBox.ValueMember = "Id";
        }

        private async void ModificarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                lblEstado.Text = "Cargando datos...";
                lblEstado.ForeColor = System.Drawing.Color.Blue;

                await CargarPersonasAsync();
                await CargarPlanesAsync();

                // Cargar datos del usuario
                nombreUsuarioBox.Text = usuario.NombreUsuario;
                claveBox.Text = ""; // No mostrar la clave actual por seguridad
                claveBox.PlaceholderText = "Dejar en blanco para mantener la actual";
                emailBox.Text = usuario.Email;
                tipoBox.Text = usuario.Tipo;
                legajoBox.Text = usuario.Legajo ?? "";
                habilitadoCheck.Checked = usuario.Habilitado;

                if (personaComboBox.Items.Count > 0)
                    personaComboBox.SelectedValue = usuario.PersonaId;

                if (planComboBox.Items.Count > 0)
                    planComboBox.SelectedValue = usuario.PlanId ?? 0;

                lblEstado.Text = "";
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error al cargar el formulario: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                modificarButton.Enabled = false;
                lblEstado.Text = "Guardando cambios...";
                lblEstado.ForeColor = System.Drawing.Color.Blue;

                usuario.NombreUsuario = nombreUsuarioBox.Text.Trim();
                usuario.Clave = claveBox.Text; // Si está vacío, el servicio mantendrá la actual
                usuario.Email = emailBox.Text.Trim();
                usuario.Tipo = tipoBox.Text;
                usuario.Legajo = string.IsNullOrWhiteSpace(legajoBox.Text) ? null : legajoBox.Text.Trim();
                usuario.Habilitado = habilitadoCheck.Checked;
                usuario.PersonaId = (int)personaComboBox.SelectedValue;

                int planSeleccionado = (int)planComboBox.SelectedValue;
                usuario.PlanId = planSeleccionado == 0 ? null : planSeleccionado;

                await UsuarioApiClient.UpdateAsync(usuario);

                lblEstado.Text = "Usuario modificado correctamente.";
                lblEstado.ForeColor = System.Drawing.Color.Green;

                MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Error al modificar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                modificarButton.Enabled = true;
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(nombreUsuarioBox.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nombreUsuarioBox.Focus();
                return false;
            }

            // Solo validar la clave si se ingresó una nueva
            if (!string.IsNullOrWhiteSpace(claveBox.Text) && claveBox.Text.Length < 6)
            {
                MessageBox.Show("La clave debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                claveBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(emailBox.Text))
            {
                MessageBox.Show("El email es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailBox.Focus();
                return false;
            }

            if (!emailBox.Text.Contains("@") || !emailBox.Text.Contains("."))
            {
                MessageBox.Show("El email no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tipoBox.Text))
            {
                MessageBox.Show("Debe seleccionar un tipo de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tipoBox.Focus();
                return false;
            }

            if (personaComboBox.SelectedValue == null || (int)personaComboBox.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar una persona.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                personaComboBox.Focus();
                return false;
            }

            // Validar plan según el tipo de usuario
            int planSeleccionado = (int)planComboBox.SelectedValue;
            if (planSeleccionado == 0)
            {
                if (tipoBox.Text == "Alumno")
                {
                    // El plan es OBLIGATORIO para alumnos
                    MessageBox.Show("Debe seleccionar un plan para los alumnos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    planComboBox.Focus();
                    return false;
                }
            }

            return true;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tipoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Opcional: Puedes habilitar/deshabilitar el legajo según el tipo
            if (tipoBox.Text == "Alumno" || tipoBox.Text == "Profesor")
            {
                legajoBox.Enabled = true;
            }

            // Actualizar el label del plan según el tipo
            if (tipoBox.Text == "Alumno")
            {
                label8.Text = "Plan: *";
                label8.ForeColor = System.Drawing.Color.Black;

                // Si el plan está en "Sin asignar", mostrar advertencia
                if (planComboBox.SelectedValue != null && (int)planComboBox.SelectedValue == 0)
                {
                    MessageBox.Show("Los alumnos deben tener un plan asignado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    planComboBox.Focus();
                }
            }
            else
            {
                label8.Text = "Plan:";
                label8.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}