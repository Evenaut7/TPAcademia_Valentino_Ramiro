using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
using DTOs;

namespace VistaEscritorio
{
    public partial class ABMEspecialidades : Form
    {
        private IEnumerable<EspecialidadDTO>? listaEspecialidades;
        public ABMEspecialidades()
        {
            InitializeComponent();
        }
        private async Task CargarTablaAsync()
        {
            listaEspecialidades = await EspecialidadApiClient.GetAllAsync();
            dgvEspecialidades.DataSource = listaEspecialidades.ToList();
        }
        private async void eliminarEspecialidades_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }

            int filaSeleccionada = dgvEspecialidades.SelectedRows[0].Index;
            if (listaEspecialidades == null)
            {
                MessageBox.Show("No hay especialdiades cargadas.");
                return;
            }

            var especialidadAEliminar = listaEspecialidades.ToList()[filaSeleccionada];
            try
            {
                await EspecialidadApiClient.DeleteAsync(especialidadAEliminar.Id);
                MessageBox.Show("Especialidad eliminada correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar la especialidad.");
            }
        }

        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            CargaEspecialidades cargaEspecialidadesForm = new();
            cargaEspecialidadesForm.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para Modificar.");
                return;
            }

            int filaSeleccionada = dgvEspecialidades.SelectedRows[0].Index;
            if (listaEspecialidades == null)
            {
                MessageBox.Show("No hay especialdiades cargadas.");
                return;
            }

            var especialidadAModificarDTO = listaEspecialidades.ToList()[filaSeleccionada];

            ModificarEspecialidad cargaEspecialidadesForm = new ModificarEspecialidad(especialidadAModificarDTO);
            cargaEspecialidadesForm.ShowDialog();
            listarButton_Click(sender, e);
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }

            int filaSeleccionada = dgvEspecialidades.SelectedRows[0].Index;
            if (listaEspecialidades == null)
            {
                MessageBox.Show("No hay especialdiades cargadas.");
                return;
            }

            var especialidadAEliminar = listaEspecialidades.ToList()[filaSeleccionada];
            try
            {
                await EspecialidadApiClient.DeleteAsync(especialidadAEliminar.Id);
                MessageBox.Show("Especialidad eliminada correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar la especialidad.");
            }
        }

        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ABMEspecialidades_Load(object sender, EventArgs e)
        {
            listarButton_Click(sender, e);
        }
    }
}
