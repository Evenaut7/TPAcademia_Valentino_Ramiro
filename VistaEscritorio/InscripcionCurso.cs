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
        private CursoService cursoService = new CursoService();
        private IEnumerable<CursoDTO>? listaCursos;
        private IEnumerable<MateriaDTO>? listaMaterias;
        private IEnumerable<ComisionDTO>? listaComisiones;

        public InscripcionCurso()
        {
            InitializeComponent();
        }

        private async void InscripcionCurso_Load(object sender, EventArgs e)
        {
            // Deshabilitar el botón mientras se cargan los datos
            btnInscribirse.Enabled = false;
            btnInscribirse.Text = "Cargando...";

            try
            {
                await CargarCursosAsync();
                btnInscribirse.Enabled = true;
                btnInscribirse.Text = "Inscribirse";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los cursos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnInscribirse.Enabled = false;
            }
        }

        private async Task CargarCursosAsync()
        {
            try
            {
                // Cargar datos de las APIs
                listaCursos = await CursoApiClient.GetAllAsync();
                listaMaterias = await MateriaApiClient.GetAllAsync();
                listaComisiones = await ComisionApiClient.GetAllAsync();

                if (listaCursos == null || listaMaterias == null || listaComisiones == null)
                {
                    MessageBox.Show("No se pudieron cargar los datos de las APIs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ActualizarGridCursos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar cursos desde API: {ex.Message}", ex);
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
                        c.AnioCalendario,
                        c.Cupo,
                        Materia = listaMaterias?.FirstOrDefault(m => m.Id == c.MateriaId)?.Descripcion ?? "Materia no encontrada",
                        Comision = listaComisiones?.FirstOrDefault(co => co.Id == c.ComisionId)?.Nombre ?? "Comisión no encontrada"
                    })
                    .ToList();

                if (listaConNombre == null || !listaConNombre.Any())
                {
                    MessageBox.Show("No hay cursos disponibles para el año actual.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCursos.DataSource = null;
                    return;
                }

                dgvCursos.DataSource = listaConNombre;
                dgvCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCursos.ReadOnly = true;

                // Ajustar columnas
                dgvCursos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el grid: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un curso.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener el ID del curso seleccionado
                int cursoId = (int)dgvCursos.SelectedRows[0].Cells["Id"].Value;
                var curso = listaCursos?.FirstOrDefault(c => c.Id == cursoId);

                if (curso == null)
                {
                    MessageBox.Show("Curso no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener nombre de materia y comisión para mostrar
                var materia = listaMaterias?.FirstOrDefault(m => m.Id == curso.MateriaId)?.Descripcion ?? "Materia no encontrada";
                var comision = listaComisiones?.FirstOrDefault(co => co.Id == curso.ComisionId)?.Nombre ?? "Comisión no encontrada";

                var mensaje = $"¿Desea inscribirse al curso de materia '{materia}' en la comisión '{comision}'?";
                var result = MessageBox.Show(mensaje, "Confirmar inscripción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Deshabilitar botón durante la operación
                btnInscribirse.Enabled = false;
                btnInscribirse.Text = "Procesando...";

                // Obtener ID del alumno y validar rol
                int alumnoId = await AuthServiceProvider.Instance.GetUserIdAsync();
                string rol = await UsuarioApiClient.getUserRole(alumnoId);

                if (rol != "Usuario")
                {
                    MessageBox.Show("Solo los alumnos pueden inscribirse en cursos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnInscribirse.Enabled = true;
                    btnInscribirse.Text = "Inscribirse";
                    return;
                }

                // Crear DTO y enviar al API
                var inscripcionDto = new AlumnoInscripcionDTO
                {
                    AlumnoId = alumnoId,
                    CursoId = cursoId,
                    Condicion = "Inscripto",
                    Nota = null
                };

                await API.Clients.AlumnoInscripcionApiClient.AddAsync(inscripcionDto);
                MessageBox.Show("Inscripción realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar los cursos
                await CargarCursosAsync();
                btnInscribirse.Text = "Inscribirse";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inscribirse: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnInscribirse.Enabled = true;
                btnInscribirse.Text = "Inscribirse";
            }
            finally
            {
                btnInscribirse.Enabled = true;
                if (btnInscribirse.Text == "Procesando...")
                    btnInscribirse.Text = "Inscribirse";
            }
        }

        private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}