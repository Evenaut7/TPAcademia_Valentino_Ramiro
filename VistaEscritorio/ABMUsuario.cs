using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMUsuario : Form
    {
        private IEnumerable<UsuarioDTO>? listaUsuarios;
        private List<PersonaDTO>? listaPersonas;

        public ABMUsuario()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            try
            {
                listaUsuarios = await UsuarioApiClient.GetAllAsync();
                var personas = await PersonaApiClient.GetAllAsync();
                listaPersonas = personas?.ToList();

                var listaConNombre = listaUsuarios
                    .Select(u => new
                    {
                        u.Id,
                        u.NombreUsuario,
                        u.Email,
                        u.Tipo,
                        Persona = listaPersonas?.FirstOrDefault(p => p.Id == u.PersonaId)?.Nombre ?? "No asignado",
                        u.Habilitado
                    })
                    .ToList();

                dgvUsuario.DataSource = listaConNombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la tabla: {ex.Message}");
            }
        }

        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }

            int filaSeleccionada = dgvUsuario.SelectedRows[0].Index;
            var usuarioAEliminar = listaUsuarios!.ToList()[filaSeleccionada];

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?",
                "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await UsuarioApiClient.DeleteAsync(usuarioAEliminar.Id);
                    MessageBox.Show("Usuario eliminado correctamente.");
                    await CargarTablaAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar el usuario: {ex.Message}");
                }
            }
        }

        private async void ABMUsuario_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            var form = new CargarUsuario();
            form.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para modificar.");
                return;
            }

            int filaSeleccionada = dgvUsuario.SelectedRows[0].Index;
            var usuarioAModificar = listaUsuarios!.ToList()[filaSeleccionada];

            var form = new ModificarUsuario(usuarioAModificar);
            form.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}