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
        private List<PlanDTO>? listaPlanes;

        public CargarUsuario()
        {
            InitializeComponent();
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

            var lista = listaPlanes
                .Select(p => new
                {
                    p.Id,
                    Descripcion = $"{p.Descripcion} - {listaEspecialidades?.FirstOrDefault(e => e.Id == p.EspecialidadId)?.Descripcion ?? "Especialidad no encontrada"}"
                })
                .ToList();

            planComboBox.DataSource = lista;
            planComboBox.DisplayMember = "Descripcion";
            planComboBox.ValueMember = "Id";
        }

        private async void CargarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                lblEstado.Text = "Cargando datos...";
                lblEstado.ForeColor = System.Drawing.Color.Blue;

                await CargarPersonasAsync();
                await CargarPlanesAsync();

                tipoBox.Text = "Alumno";

                lblEstado.Text = "";
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error al cargar el formulario: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;
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

                agregarButton.Enabled = false;
                lblEstado.Text = "Guardando usuario...";
                lblEstado.ForeColor = System.Drawing.Color.Blue;

                var nuevoUsuario = new UsuarioDTO
                {
                    NombreUsuario = nombreUsuarioBox.Text.Trim(),
                    Clave = claveBox.Text,
                    Email = emailBox.Text.Trim(),
                    Tipo = tipoBox.Text,
                    Legajo = string.IsNullOrWhiteSpace(legajoBox.Text) ? null : legajoBox.Text.Trim(),
                    Habilitado = habilitadoCheck.Checked,
                    PersonaId = (int)personaComboBox.SelectedValue,
                    PlanId = planComboBox.SelectedValue != null ? (int)planComboBox.SelectedValue : (int?)null
                };

                await UsuarioApiClient.AddAsync(nuevoUsuario);

                lblEstado.Text = "Usuario agregado correctamente.";
                lblEstado.ForeColor = System.Drawing.Color.Green;

                MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                agregarButton.Enabled = true;
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

            if (string.IsNullOrWhiteSpace(claveBox.Text))
            {
                MessageBox.Show("La clave es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                claveBox.Focus();
                return false;
            }

            if (claveBox.Text.Length < 6)
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
            if (planComboBox.SelectedValue == null || (int)planComboBox.SelectedValue == 0)
            {
                if (tipoBox.Text == "Alumno")
                {
                    // El plan es OBLIGATORIO para alumnos
                    MessageBox.Show("Debe seleccionar un plan para los alumnos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    planComboBox.Focus();
                    return false;
                }
                else
                {
                    // El plan es opcional para otros tipos
                    var resultado = MessageBox.Show(
                        "No ha seleccionado un plan. ¿Desea continuar sin asignar un plan?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado != DialogResult.Yes)
                    {
                        planComboBox.Focus();
                        return false;
                    }
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
            }
            else
            {
                label8.Text = "Plan:";
                label8.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}