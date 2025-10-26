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
        private int alumnoId;
        private IEnumerable<AlumnoInscripcionDTO>? listaInscripciones;
        private IEnumerable<CursoDTO>? listaCursos;
        private IEnumerable<MateriaDTO>? listaMaterias;
        private IEnumerable<ComisionDTO>? listaComisiones;

        public MisCursos()
        {
            InitializeComponent();
        }

        private async void MisCursos_Load(object sender, EventArgs e)
        {
            btnDesuscribirse.Enabled = false;
            btnDesuscribirse.Text = "Cargando...";

            try
            {
                // Obtener ID del alumno actual
                alumnoId = await AuthServiceProvider.Instance.GetUserIdAsync();

                // Cargar datos
                await CargarMisCursosAsync();

                btnDesuscribirse.Enabled = true;
                btnDesuscribirse.Text = "Desuscribirse";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tus cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDesuscribirse.Enabled = false;
            }
        }

        private async Task CargarMisCursosAsync()
        {
            try
            {
                // Cargar TODAS las inscripciones
                listaInscripciones = await AlumnoInscripcionApiClient.GetAllAsync();

                // Cargar datos relacionados
                listaCursos = await CursoApiClient.GetAllAsync();
                listaMaterias = await MateriaApiClient.GetAllAsync();
                listaComisiones = await ComisionApiClient.GetAllAsync();

                if (listaInscripciones == null || listaCursos == null || listaMaterias == null || listaComisiones == null)
                {
                    MessageBox.Show("No se pudieron cargar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ActualizarGridCursos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar inscripciones: {ex.Message}", ex);
            }
        }

        private void ActualizarGridCursos()
        {
            try
            {
                // Filtrar solo las inscripciones del alumno actual
                var misCursos = listaInscripciones?
                    .Where(inscripcion => inscripcion.AlumnoId == alumnoId)
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
                    MessageBox.Show("No estás inscripto en ningún curso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMisCursos.DataSource = null;
                    return;
                }

                dgvMisCursos.DataSource = misCursos;
                dgvMisCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMisCursos.ReadOnly = true;

                // Ajustar columnas
                dgvMisCursos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Ocultar columnas innecesarias
                dgvMisCursos.Columns["InscripcionId"].Visible = false;
                dgvMisCursos.Columns["CursoId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDesuscribirse_Click(object sender, EventArgs e)
        {
            if (dgvMisCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un curso para desuscribirse.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string materia = dgvMisCursos.SelectedRows[0].Cells["Materia"].Value?.ToString() ?? "desconocida";
                string comision = dgvMisCursos.SelectedRows[0].Cells["Comision"].Value?.ToString() ?? "desconocida";

                var resultado = MessageBox.Show(
                    $"¿Está seguro que desea desuscribirse del curso de '{materia}' en la comisión '{comision}'?",
                    "Confirmar desuscripción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                    return;

                int inscripcionId = (int)dgvMisCursos.SelectedRows[0].Cells["InscripcionId"].Value;

                btnDesuscribirse.Enabled = false;
                btnDesuscribirse.Text = "Procesando...";

                // Eliminar la inscripción
                await AlumnoInscripcionApiClient.DeleteAsync(inscripcionId);

                MessageBox.Show("Te has desuscripto exitosamente del curso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la lista
                await CargarMisCursosAsync();
                btnDesuscribirse.Text = "Desuscribirse";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desuscribirse: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDesuscribirse.Enabled = true;
                btnDesuscribirse.Text = "Desuscribirse";
            }
            finally
            {
                btnDesuscribirse.Enabled = true;
                if (btnDesuscribirse.Text == "Procesando...")
                    btnDesuscribirse.Text = "Desuscribirse";
            }
        }
    }
}