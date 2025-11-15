using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ABMPersona : Form
    {
        private IEnumerable<PersonaDTO>? listaPersonas;

        public ABMPersona()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            var personas = await PersonaApiClient.GetAllAsync();
            listaPersonas = personas;
            dgvPersonas.DataSource = personas?.ToList();
        }

        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            PersonaRegistrar personaRegistrar = new PersonaRegistrar();
            personaRegistrar.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para modificar.");
                return;
            }
            int filaSeleccionada = dgvPersonas.SelectedRows[0].Index;
            if (listaPersonas == null)
            {
                MessageBox.Show("No hay personas cargadas.");
                return;
            }
            var personaAModificar = listaPersonas.ToList()[filaSeleccionada];
            ModificarPersona modificarPersonaForm = new ModificarPersona(personaAModificar);
            modificarPersonaForm.ShowDialog();
            listarButton_Click(sender, e);
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }
            int filaSeleccionada = dgvPersonas.SelectedRows[0].Index;
            if (listaPersonas == null)
            {
                MessageBox.Show("No hay personas cargadas.");
                return;
            }
            var personaAEliminar = listaPersonas.ToList()[filaSeleccionada];

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar esta persona?",
                "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await PersonaApiClient.DeleteAsync(personaAEliminar.Id);
                    MessageBox.Show("Persona eliminada correctamente.");
                    await CargarTablaAsync();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo eliminar la persona.");
                }
            }
        }

        private void dgvPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private async void ABMPersona_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }
    }
}