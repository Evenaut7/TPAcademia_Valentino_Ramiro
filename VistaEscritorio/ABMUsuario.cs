using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ABMUsuario : Form
    {
        private IEnumerable<UsuarioDTO>? listaUsuarios;

        public ABMUsuario()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            listaUsuarios = await UsuarioApiClient.GetAllAsync();
            dgvUsuarios.DataSource = listaUsuarios.ToList();
        }

        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }
            int filaSeleccionada = dgvUsuarios.SelectedRows[0].Index;
            if (listaUsuarios == null)
            {
                MessageBox.Show("No hay usuarios cargados.");
                return;
            }
            var usuarioAEliminar = listaUsuarios.ToList()[filaSeleccionada];
            try
            {
                await UsuarioApiClient.DeleteAsync(usuarioAEliminar.Id);
                MessageBox.Show("Usuario eliminado correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar el usuario.");
            }
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            UsuarioRegistrar usuarioRegistrar = new UsuarioRegistrar();
            usuarioRegistrar.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para modificar.");
                return;
            }
            int filaSeleccionada = dgvUsuarios.SelectedRows[0].Index;
            if (listaUsuarios == null)
            {
                MessageBox.Show("No hay usuarios cargados.");
                return;
            }
            var usuarioAModificar = listaUsuarios.ToList()[filaSeleccionada];
            ModificarUsuario modificarUsuarioForm = new ModificarUsuario(usuarioAModificar);
            modificarUsuarioForm.ShowDialog();
            listarButton_Click(sender, e);
        }

        private async void UsuarioABM_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}