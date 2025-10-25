using API.Clients;
using Application.Services;
using Domain.Model;
using DTOs;
using System;
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
            // Use async load pattern
            this.Load += async (s, e) => await CargarCursosAsync();
        }

        private async Task CargarCursosAsync()
        {
            listaCursos = await CursoApiClient.GetAllAsync();
            listaMaterias = await MateriaApiClient.GetAllAsync();
            listaComisiones = await ComisionApiClient.GetAllAsync();

            int anioActual = DateTime.Now.Year;
            var listaConNombre = listaCursos
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

            dgvCursos.DataSource = listaConNombre;
            dgvCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCursos.ReadOnly = true;
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un curso.");
                return;
            }

            var cursoId = (int)dgvCursos.SelectedRows[0].Cells["Id"].Value;
            var curso = listaCursos?.FirstOrDefault(c => c.Id == cursoId);
            if (curso == null)
            {
                MessageBox.Show("Curso no encontrado.");
                return;
            }

            var mensaje = $"¿Desea inscribirse al curso de materia '{curso.MateriaId}' en la comisión '{curso.ComisionId}'?";
            var result = MessageBox.Show(mensaje, "Confirmar inscripción", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Lógica para inscribir al alumno
                // cursoService.InscribirAlumno(alumnoId, curso.Id);
                MessageBox.Show("Inscripción realizada con éxito.");
            }
        }

        private void InscripcionCurso_Load(object sender, EventArgs e)
        {
            if (listaCursos != null && listaMaterias != null && listaComisiones != null)
            {
                int anioActual = DateTime.Now.Year;
                var cursos = listaCursos
                    .Where(c => c.AnioCalendario == anioActual)
                    .Select(c => new
                    {
                        c.Id,
                        c.AnioCalendario,
                        c.Cupo,
                        Materia = listaMaterias.FirstOrDefault(m => m.Id == c.MateriaId)?.Descripcion ?? "Materia no encontrada",
                        Comision = listaComisiones.FirstOrDefault(co => co.Id == c.ComisionId)?.Nombre ?? "Comisión no encontrada"
                    })
                    .ToList();

                dgvCursos.DataSource = cursos;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 1. Get current user ID and role
            int alumnoId = await AuthServiceProvider.Instance.GetUserIdAsync();
            string rol = await UsuarioApiClient.getUserRole(alumnoId);

            if (rol != "Usuario")
            {
                MessageBox.Show("Solo los alumnos pueden inscribirse en cursos.");
                return;
            }

            // 2. Get selected course
            if (dgvCursos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un curso.");
                return;
            }

            int cursoId = (int)dgvCursos.SelectedRows[0].Cells["Id"].Value;

            // 3. Confirmation dialog
            var result = MessageBox.Show(
                $"¿Desea inscribirse al curso con ID '{cursoId}'?",
                "Confirmar inscripción",
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            // 4. Create DTO and call API
            var inscripcionDto = new AlumnoInscripcionDTO
            {
                AlumnoId = alumnoId,
                CursoId = cursoId,
                Condicion = "Inscripto", // Default condition
                Nota = null
            };

            try
            {
                await API.Clients.AlumnoInscripcionApiClient.AddAsync(inscripcionDto);
                MessageBox.Show("Inscripción realizada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inscribirse: {ex.Message}");
            }
        }
    }
}