using API.Clients; // Asumo la existencia de ComisionApiClient
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMComision : Form
    {
        private IEnumerable<ComisionDTO>? listaComisiones;

        // Se asume la existencia de DTOs.ComisionDTO: {Id, Nombre, AnioEspecialidad, PlanId}

        public ABMComision()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            // Se asume que existe un ComisionApiClient con métodos GetAllAsync()
            listaComisiones = await ComisionApiClient.GetAllAsync();

            // Si necesitaras resolver el nombre del Plan (similar a como ABMCurso resuelve Materia y Comision):
            /*
            var listaPlanes = await PlanApiClient.GetAllAsync(); // Asumiendo PlanDTO y PlanApiClient
            var listaConNombre = listaComisiones.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.AnioEspecialidad,
                c.PlanId,
                // Plan = listaPlanes.FirstOrDefault(item => item.Id == c.PlanId)?.Nombre ?? "Plan no encontrado" 
            }).ToList();
            dgvComision.DataSource = listaConNombre;
            */

            // Para simplicidad, se carga el DTO directamente, mostrando Id, Nombre, AnioEspecialidad y PlanId.
            dgvComision.DataSource = listaComisiones?.ToList();
        }

        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async void ABMComision_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            CargaComision cargaComision = new CargaComision();
            cargaComision.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvComision.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para Modificar.");
                return;
            }

            int filaSeleccionada = dgvComision.SelectedRows[0].Index;
            if (listaComisiones == null)
            {
                MessageBox.Show("No hay comisiones cargadas");
                return;
            }

            var comisionAModificarDTO = listaComisiones.ToList()[filaSeleccionada];

            ModificarComision cargaComisionForm = new ModificarComision(comisionAModificarDTO);
            cargaComisionForm.ShowDialog();
            listarButton_Click(sender, e);
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvComision.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }

            int filaSeleccionada = dgvComision.SelectedRows[0].Index;

            var comisionesLista = listaComisiones?.ToList();

            if (comisionesLista == null || !comisionesLista.Any())
            {
                MessageBox.Show("No hay comisiones cargadas.");
                return;
            }

            var comisionAEliminar = comisionesLista[filaSeleccionada];

            try
            {
                await ComisionApiClient.DeleteAsync(comisionAEliminar.Id);
                MessageBox.Show("Comisión eliminada correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception except)
            {
                MessageBox.Show("No se pudo eliminar la comisión." + except );
            }
        }
    }
}