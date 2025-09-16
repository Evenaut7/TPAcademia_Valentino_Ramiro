using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;
namespace VistaEscritorio
{
    public partial class ABMmaterias : Form
    {
        private IEnumerable<MateriaDTO>? listaMaterias;

        public ABMmaterias()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            listaMaterias = await MateriaApiClient.GetAllAsync();
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
            try
            {
                await MateriaApiClient.DeleteAsync(materiaAEliminar.Id);
                MessageBox.Show("Materia eliminada correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar la materia.");
            }
        }

        private void agegarMaterias_Click(object sender, EventArgs e)
        {
            CargaMaterias cargaMateriasForm = new();
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

            var materiaAModificarDTO = listaMaterias.ToList()[filaSeleccionada];

            // Pass MateriaDTO directly to ModificarMateria
            ModificarMateria cargaMateriasForm = new ModificarMateria(materiaAModificarDTO);
            cargaMateriasForm.ShowDialog();
            listarMaterias_Click(sender, e);
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}