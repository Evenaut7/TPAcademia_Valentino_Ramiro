using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMCurso : Form
    {
        private IEnumerable<CursoDTO>? listaCursos;
        private IEnumerable<MateriaDTO>? listaMaterias;
        private IEnumerable<ComisionDTO>? listaComisiones;
        public ABMCurso()
        {
            InitializeComponent();
        }
        private async Task CargarTablaAsync()
        {
            listaCursos = await CursoApiClient.GetAllAsync();
            listaMaterias = await MateriaApiClient.GetAllAsync();
            listaComisiones = await ComisionApiClient.GetAllAsync();

            var listaConNombre = listaCursos.Select(c => new
            {
                c.Id,
                c.AnioCalendario,
                c.Cupo,
                Materia = listaMaterias.FirstOrDefault(item => item.Id == c.MateriaId)?.Descripcion ?? "Materia no encontrada",
                Comision = listaComisiones.FirstOrDefault(item => item.Id == c.ComisionId)?.Nombre ?? "Comisión no encontrada"
            }).ToList();

            dgvCurso.DataSource = listaConNombre;
        }
        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }
        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvCurso.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }
            int filaSeleccionada = dgvCurso.SelectedRows[0].Index;
            var listaCursos = await CursoApiClient.GetAllAsync();
            if (listaCursos == null)
            {
                MessageBox.Show("No hay cursos cargados.");
                return;
            }
            var cursoAEliminar = listaCursos.ToList()[filaSeleccionada];
            try
            {
                await CursoApiClient.DeleteAsync(cursoAEliminar.Id);
                MessageBox.Show("Curso eliminado correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar el curso.");
            }
        }

        private async void ABMCurso_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            CargarCursos cargarCursos = new CargarCursos();
            cargarCursos.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvCurso.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para Modificar.");
                return;
            }

            int filaSeleccionada = dgvCurso.SelectedRows[0].Index;
            if (listaCursos == null)
            {
                MessageBox.Show("No hay cursos cargados");
                return;
            }

            var cursoAModificarDTO = listaCursos.ToList()[filaSeleccionada];

            ModificarCurso cargaCursosForm = new ModificarCurso(cursoAModificarDTO);
            cargaCursosForm.ShowDialog();
            listarButton_Click(sender, e);
        }

        private async void eliminarButton_Click_1(object sender, EventArgs e)
        {
            if (dgvCurso.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }
            int filaSeleccionada = dgvCurso.SelectedRows[0].Index;
            var listaCursos = dgvCurso.DataSource as List<CursoDTO>;
            if (listaCursos == null)
            {
                MessageBox.Show("No hay cursos cargados.");
                return;
            }
            var cursoAEliminar = listaCursos[filaSeleccionada];
            try
            {
                await CursoApiClient.DeleteAsync(cursoAEliminar.Id);
                MessageBox.Show("Curso eliminado correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar el curso.");
            }

        }
    }
}
