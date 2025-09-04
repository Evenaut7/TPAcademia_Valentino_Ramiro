using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ABMplan : Form
    {
        private IEnumerable<PlanDTO>? listaPlanes;

        public ABMplan()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            listaPlanes = await PlanApiClient.GetAllAsync();
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
            try
            {
                await PlanApiClient.DeleteAsync(planAEliminar.Id);
                MessageBox.Show("Plan eliminado correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar el plan.");
            }
        }

        private void agregarPlanes_Click(object sender, EventArgs e)
        {
            CargaPlanes cargaPlanesForm = new();
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

            var planAModificarDTO = listaPlanes.ToList()[filaSeleccionada];

            // Pass the PlanDTO directly to the ModificarPlan form
            ModificarPlan modificarPlanForm = new ModificarPlan(planAModificarDTO);
            modificarPlanForm.ShowDialog();
            listarPlanes_Click(sender, e);
        }
    }
}
