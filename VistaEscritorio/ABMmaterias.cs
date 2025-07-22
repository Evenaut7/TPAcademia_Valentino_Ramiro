using Models;
using Negocio;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMmaterias : Form
    {
        private IEnumerable<Materia>? listaMaterias;

        public ABMmaterias()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            listaMaterias = await MateriaNegocio.GetAll();
            dgvMaterias.DataSource = listaMaterias.ToList();
        }

        private async void listarMaterias_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async void eliminarMaterias_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }

            int filaSeleccionada = dgvMaterias.SelectedRows[0].Index;
            if (listaMaterias == null)
            {
                MessageBox.Show("No hay materias cargadas.");
                return;
            }

            var materiaAEliminar = listaMaterias.ToList()[filaSeleccionada];
            bool eliminado = await MateriaNegocio.Delete(materiaAEliminar);

            if (eliminado)
            {
                MessageBox.Show("Materia eliminada correctamente.");
                await CargarTablaAsync();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la materia.");
            }
        }

        private void agegarMaterias_Click(object sender, EventArgs e)
        {
            CargaMaterias cargaMateriasForm = new CargaMaterias();
            cargaMateriasForm.ShowDialog();
            listarMaterias_Click(sender, e);
        }

        private void modificarMateria_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para Modificar.");
                return;
            }

            int filaSeleccionada = dgvMaterias.SelectedRows[0].Index;
            if (listaMaterias == null)
            {
                MessageBox.Show("No hay materias cargadas.");
                return;
            }

            var materiaAModificar = listaMaterias.ToList()[filaSeleccionada];
            ModificarMateria cargaMateriasForm = new ModificarMateria(materiaAModificar);
            cargaMateriasForm.ShowDialog();
            listarMaterias_Click(sender, e);
        }
    }
}