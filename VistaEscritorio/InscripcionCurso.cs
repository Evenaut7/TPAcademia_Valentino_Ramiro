using API.Clients;
using Application.Services;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class InscripcionCurso : Form
    {
        private IEnumerable<CursoDTO>? listaCursos;
        private IEnumerable<MateriaDTO>? listaMaterias;
        private IEnumerable<ComisionDTO>? listaComisiones;
        private bool isProcessing = false;

        public InscripcionCurso()
        {
            InitializeComponent();
        }

        private async void InscripcionCurso_Load(object sender, EventArgs e)
        {
            // Verificar rol del usuario
            try
            {
                int usuarioId = await AuthServiceProvider.Instance.GetUserIdAsync();
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

                await CargarCursosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnInscribirse.Enabled = false;
            }
        }

        private async Task CargarCursosAsync()
        {
            btnInscribirse.Enabled = false;
            lblEstado.Text = "Cargando cursos...";
            lblEstado.ForeColor = System.Drawing.Color.Blue;

            try
            {
                listaCursos = await CursoApiClient.GetAllAsync();
                listaMaterias = await MateriaApiClient.GetAllAsync();
                listaComisiones = await ComisionApiClient.GetAllAsync();

                // Obtener inscripciones del usuario actual
                int usuarioId = await AuthServiceProvider.Instance.GetUserIdAsync();
                var inscripciones = await AlumnoInscripcionApiClient.GetAllAsync();
                var cursosInscriptoIds = inscripciones
                    .Where(i => i.UsuarioId == usuarioId)
                    .Select(i => i.CursoId)
                    .ToHashSet();

                // Filtrar cursos: año actual, cupo > 0, no inscripto
                int anioActual = DateTime.Now.Year;
                listaCursos = listaCursos?
                    .Where(c => c.AnioCalendario == anioActual && c.Cupo > 0 && !cursosInscriptoIds.Contains(c.Id))
                    .ToList();

                ActualizarGridCursos();
                lblEstado.Text = "";
                btnInscribirse.Enabled = true;
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error al cargar cursos: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;
                throw;
            }
        }

        private void ActualizarGridCursos()
        {
            try
            {
                int anioActual = DateTime.Now.Year;

                var listaConNombre = listaCursos?
                    .Where(c => c.AnioCalendario == anioActual)
                    .Select(c => new
                    {
                        c.Id,
                        Materia = listaMaterias?.FirstOrDefault(m => m.Id == c.MateriaId)?.Descripcion ?? "Materia no encontrada",
                        Comision = listaComisiones?.FirstOrDefault(co => co.Id == c.ComisionId)?.Nombre ?? "Comisión no encontrada",
                        Año = c.AnioCalendario,
                        c.Cupo
                    })
                    .ToList();

                if (listaConNombre == null || !listaConNombre.Any())
                {
                    lblEstado.Text = "No hay cursos disponibles para el año actual.";
                    lblEstado.ForeColor = System.Drawing.Color.DarkOrange;
                    dgvCursos.DataSource = null;
                    btnInscribirse.Enabled = false;
                    return;
                }

                dgvCursos.DataSource = listaConNombre;
                dgvCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCursos.ReadOnly = true;
                dgvCursos.MultiSelect = false;

                // Ocultar la columna Id
                if (dgvCursos.Columns["Id"] != null)
                    dgvCursos.Columns["Id"].Visible = false;

                // Ajustar columnas
                dgvCursos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el grid: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un curso.",
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
                btnInscribirse.Enabled = false;
                lblEstado.Text = "Procesando inscripción...";
                lblEstado.ForeColor = System.Drawing.Color.Blue;

                // Obtener el ID del curso seleccionado
                int cursoId = (int)dgvCursos.SelectedRows[0].Cells["Id"].Value;
                string materia = dgvCursos.SelectedRows[0].Cells["Materia"].Value?.ToString() ?? "desconocida";
                string comision = dgvCursos.SelectedRows[0].Cells["Comision"].Value?.ToString() ?? "desconocida";

                var mensaje = $"¿Desea inscribirse al curso de '{materia}' en la comisión '{comision}'?";
                var result = MessageBox.Show(mensaje,
                    "Confirmar inscripción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    lblEstado.Text = "";
                    return;
                }

                // Obtener ID del alumno y validar rol
                int usuarioId = await AuthServiceProvider.Instance.GetUserIdAsync();
                string rol = await UsuarioApiClient.getUserRole(usuarioId);

                if (rol != "Alumno")
                {
                    MessageBox.Show("Solo los alumnos pueden inscribirse en cursos.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    lblEstado.Text = "";
                    return;
                }

                // Crear DTO y enviar al API
                var inscripcionDto = new AlumnoInscripcionDTO
                {
                    UsuarioId = usuarioId,
                    CursoId = cursoId,
                    Condicion = "Inscripto",
                    Nota = null
                };

                await AlumnoInscripcionApiClient.AddAsync(inscripcionDto);

                lblEstado.Text = "Inscripción realizada correctamente.";
                lblEstado.ForeColor = System.Drawing.Color.Green;

                MessageBox.Show("Inscripción realizada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Recargar los cursos
                await CargarCursosAsync();
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error: {ex.Message}";
                lblEstado.ForeColor = System.Drawing.Color.Red;

                string errorMsg = !string.IsNullOrWhiteSpace(ex.Message)
                    ? ex.Message
                    : "Ocurrió un error inesperado al intentar inscribirse.";

                MessageBox.Show($"Error al inscribirse: {errorMsg}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btnInscribirse.Enabled = dgvCursos.Rows.Count > 0;
            }
        }

        private void dgvCursos_SelectionChanged(object sender, EventArgs e)
        {
            btnInscribirse.Enabled = dgvCursos.SelectedRows.Count > 0 && !isProcessing;
        }
    }
}