using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class MisCursos : Form
    {
        private int usuarioId;
        private IEnumerable<AlumnoInscripcionDTO>? listaInscripciones;
        private IEnumerable<CursoDTO>? listaCursos;
        private IEnumerable<MateriaDTO>? listaMaterias;
        private IEnumerable<ComisionDTO>? listaComisiones;
        private bool isProcessing = false;

        public MisCursos()
        {
            InitializeComponent();
        }

        private async void MisCursos_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar rol del usuario
                usuarioId = await AuthServiceProvider.Instance.GetUserIdAsync();
                string rol = await UsuarioApiClient.getUserRole(usuarioId);

                if (rol != "Alumno")
                {
                    MessageBox.Show("Solo los alumnos pueden acceder a esta sección.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                await CargarMisCursosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tus cursos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnDesuscribirse.Enabled = false;
            }
        }

        private async Task CargarMisCursosAsync()
        {
            btnDesuscribirse.Enabled = false;
            lblEstado.Text = "Cargando cursos...";
            lblEstado.ForeColor = System.Drawing.Color.Blue;

            try
            {
                // Cargar todas las inscripciones
                listaInscripciones = await AlumnoInscripcionApiClient.GetAllAsync();

                // Cargar datos relacionados
                listaCursos = await CursoApiClient.GetAllAsync();
                listaMaterias = await MateriaApiClient.GetAllAsync();
                listaComisiones = await ComisionApiClient.GetAllAsync();

                if (listaInscripciones == null || listaCursos == null ||
                    listaMaterias == null || listaComisiones == null)
                {
                    lblEstado.Text = "No se pudieron cargar los datos.";
                    lblEstado.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show("No se pudieron cargar los datos.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                ActualizarGridCursos();
                lblEstado.Text = "";
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error al cargar inscripciones: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;
                throw;
            }
        }

        private void ActualizarGridCursos()
        {
            try
            {
                // Filtrar solo las inscripciones del alumno actual
                var misCursos = listaInscripciones?
                    .Where(inscripcion => inscripcion.UsuarioId == usuarioId)
                    .Select(inscripcion =>
                    {
                        var curso = listaCursos?.FirstOrDefault(c => c.Id == inscripcion.CursoId);
                        var materia = listaMaterias?.FirstOrDefault(m => m.Id == curso?.MateriaId);
                        var comision = listaComisiones?.FirstOrDefault(co => co.Id == curso?.ComisionId);

                        return new
                        {
                            InscripcionId = inscripcion.Id,
                            CursoId = inscripcion.CursoId,
                            Materia = materia?.Descripcion ?? "Materia no encontrada",
                            Comision = comision?.Nombre ?? "Comisión no encontrada",
                            Año = curso?.AnioCalendario ?? 0,
                            Condicion = inscripcion.Condicion,
                            Nota = inscripcion.Nota.HasValue ? inscripcion.Nota.Value.ToString("F2") : "-"
                        };
                    })
                    .ToList();

                if (misCursos == null || !misCursos.Any())
                {
                    lblEstado.Text = "No estás inscripto en ningún curso.";
                    lblEstado.ForeColor = System.Drawing.Color.DarkOrange;
                    dgvMisCursos.DataSource = null;
                    btnDesuscribirse.Enabled = false;
                    return;
                }

                dgvMisCursos.DataSource = misCursos;
                dgvMisCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMisCursos.ReadOnly = true;
                dgvMisCursos.MultiSelect = false;

                // Ocultar columnas innecesarias
                if (dgvMisCursos.Columns["InscripcionId"] != null)
                    dgvMisCursos.Columns["InscripcionId"].Visible = false;
                if (dgvMisCursos.Columns["CursoId"] != null)
                    dgvMisCursos.Columns["CursoId"].Visible = false;

                // Ajustar columnas
                dgvMisCursos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                btnDesuscribirse.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el grid: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnDesuscribirse_Click(object sender, EventArgs e)
        {
            if (dgvMisCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un curso para desuscribirse.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (isProcessing)
                return;

            try
            {
                isProcessing = true;
                btnDesuscribirse.Enabled = false;

                string materia = dgvMisCursos.SelectedRows[0].Cells["Materia"].Value?.ToString() ?? "desconocida";
                string comision = dgvMisCursos.SelectedRows[0].Cells["Comision"].Value?.ToString() ?? "desconocida";

                var resultado = MessageBox.Show(
                    $"¿Está seguro que desea desuscribirse del curso de '{materia}' en la comisión '{comision}'?",
                    "Confirmar desuscripción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                lblEstado.Text = "Procesando desuscripción...";
                lblEstado.ForeColor = System.Drawing.Color.Blue;

                int inscripcionId = (int)dgvMisCursos.SelectedRows[0].Cells["InscripcionId"].Value;

                // Eliminar la inscripción
                await AlumnoInscripcionApiClient.DeleteAsync(inscripcionId);

                lblEstado.Text = "Te has desuscripto exitosamente del curso.";
                lblEstado.ForeColor = System.Drawing.Color.Green;

                MessageBox.Show("Te has desuscripto exitosamente del curso.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Recargar la lista
                await CargarMisCursosAsync();
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;

                MessageBox.Show($"Error al desuscribirse: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btnDesuscribirse.Enabled = dgvMisCursos.Rows.Count > 0;
            }
        }

        private void dgvMisCursos_SelectionChanged(object sender, EventArgs e)
        {
            btnDesuscribirse.Enabled = dgvMisCursos.SelectedRows.Count > 0 && !isProcessing;
        }
    }
}