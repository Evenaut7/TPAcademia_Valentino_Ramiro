using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMUsuario : Form
    {
        private IEnumerable<UsuarioDTO>? listaUsuarios;
        private List<PersonaDTO>? listaPersonas;
        private List<PlanDTO>? listaPlanes;

        public ABMUsuario()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            try
            {
                lblEstado.Text = "Cargando usuarios...";
                lblEstado.ForeColor = System.Drawing.Color.Blue;

                listaUsuarios = await UsuarioApiClient.GetAllAsync();
                var personas = await PersonaApiClient.GetAllAsync();
                listaPersonas = personas?.ToList();

                var planes = await PlanApiClient.GetAllAsync();
                listaPlanes = planes?.ToList();

                // Cargar especialidades para mostrar en la columna de Plan
                var especialidades = await EspecialidadApiClient.GetAllAsync();
                var listaEspecialidades = especialidades?.ToList();

                var listaConNombre = listaUsuarios
                    .Select(u => new
                    {
                        u.Id,
                        u.NombreUsuario,
                        u.Email,
                        u.Tipo,
                        u.Legajo,
                        Persona = listaPersonas?.FirstOrDefault(p => p.Id == u.PersonaId)?.Nombre ?? "No asignado",
                        Plan = u.PlanId.HasValue
                            ? (listaPlanes?.FirstOrDefault(pl => pl.Id == u.PlanId) != null
                                ? $"{listaPlanes.FirstOrDefault(pl => pl.Id == u.PlanId)?.Descripcion} - {listaEspecialidades?.FirstOrDefault(e => e.Id == listaPlanes.FirstOrDefault(pl => pl.Id == u.PlanId)?.EspecialidadId)?.Descripcion ?? "Especialidad no encontrada"}"
                                : "No encontrado")
                            : "Sin asignar",
                        u.Habilitado
                    })
                    .ToList();

                dgvUsuario.DataSource = listaConNombre;
                dgvUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsuario.ReadOnly = true;
                dgvUsuario.MultiSelect = false;

                // Ocultar la columna Id
                if (dgvUsuario.Columns["Id"] != null)
                    dgvUsuario.Columns["Id"].Visible = false;

                // Ajustar columnas
                dgvUsuario.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                lblEstado.Text = $"Total de usuarios: {listaConNombre.Count}";
                lblEstado.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error al cargar la tabla: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"Error al cargar la tabla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int usuarioId = (int)dgvUsuario.SelectedRows[0].Cells["Id"].Value;
                string nombreUsuario = dgvUsuario.SelectedRows[0].Cells["NombreUsuario"].Value?.ToString() ?? "desconocido";

                var resultado = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el usuario '{nombreUsuario}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                    return;

                eliminarButton.Enabled = false;
                lblEstado.Text = "Eliminando usuario...";
                lblEstado.ForeColor = System.Drawing.Color.Blue;

                await UsuarioApiClient.DeleteAsync(usuarioId);

                lblEstado.Text = "Usuario eliminado correctamente.";
                lblEstado.ForeColor = System.Drawing.Color.Green;

                MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarTablaAsync();
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show($"No se pudo eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                eliminarButton.Enabled = true;
            }
        }

        private async void ABMUsuario_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async void agregarButton_Click(object sender, EventArgs e)
        {
            var form = new CargarUsuario();
            var resultado = form.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                await CargarTablaAsync();
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int usuarioId = (int)dgvUsuario.SelectedRows[0].Cells["Id"].Value;
                var usuarioAModificar = listaUsuarios?.FirstOrDefault(u => u.Id == usuarioId);

                if (usuarioAModificar == null)
                {
                    MessageBox.Show("No se encontró el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var form = new ModificarUsuario(usuarioAModificar);
                var resultado = form.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    await CargarTablaAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuario_SelectionChanged(object sender, EventArgs e)
        {
            modificarButton.Enabled = dgvUsuario.SelectedRows.Count > 0;
            eliminarButton.Enabled = dgvUsuario.SelectedRows.Count > 0;
        }
    }
}