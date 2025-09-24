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
        public ABMCurso()
        {
            InitializeComponent();
        }
        private async Task CargarTablaAsync()
        {
            listaCursos = await CursoApiClient.GetAllAsync();
            dgvCurso.DataSource = listaCursos.ToList();
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
    }
}
