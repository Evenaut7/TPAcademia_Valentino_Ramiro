using Models;
using Negocio;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMplan : Form
    {
        private IEnumerable<Plan>? listaPlanes;

        public ABMplan()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            listaPlanes = await PlanNegocio.GetAll();
            dgvPlanes.DataSource = listaPlanes.ToList();
        }

        private async void listarPlanes_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async void eliminarPlanes_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }

            int filaSeleccionada = dgvPlanes.SelectedRows[0].Index;
            if (listaPlanes == null)
            {
                MessageBox.Show("No hay planes cargados.");
                return;
            }

            var planAEliminar = listaPlanes.ToList()[filaSeleccionada];
            bool eliminado = await PlanNegocio.Delete(planAEliminar);

            if (eliminado)
            {
                MessageBox.Show("Plan eliminado correctamente.");
                await CargarTablaAsync();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el plan.");
            }
        }

        private void agregarPlanes_Click(object sender, EventArgs e)
        {
            CargaPlanes cargaPlanesForm = new CargaPlanes();
            cargaPlanesForm.ShowDialog();
            listarPlanes_Click(sender, e);
        }

        private void modificarPlanes_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para modificar.");
                return;
            }

            int filaSeleccionada = dgvPlanes.SelectedRows[0].Index;
            if (listaPlanes == null)
            {
                MessageBox.Show("No hay planes cargados.");
                return;
            }

            var planAModificar = listaPlanes.ToList()[filaSeleccionada];
            ModificarPlan modificarPlanForm = new ModificarPlan(planAModificar);
            modificarPlanForm.ShowDialog();
            listarPlanes_Click(sender, e);
        }
    }
}
