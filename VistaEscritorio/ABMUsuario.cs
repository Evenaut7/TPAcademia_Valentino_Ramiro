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
        private List<dynamic>? listaPersonas; // alumnos + profesores

        public ABMUsuario()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            listaUsuarios = await UsuarioApiClient.GetAllAsync();

            var listaAlumnos = await AlumnoApiClient.GetAllAsync();
            var listaProfesores = await ProfesorApiClient.GetAllAsync();

            listaPersonas = listaAlumnos
                .Select(a => new { a.Id, Nombre = a.Nombre + " (Alumno)" })
                .Concat(listaProfesores.Select(p => new { p.Id, Nombre = p.Nombre + " (Profesor)" }))
                .Cast<dynamic>()
                .ToList();

            var listaConNombre = listaUsuarios.Select(u => new
            {
                u.Id,
                u.NombreUsuario,
                u.Email,
                u.Privilegio,
                u.Habilitado,
                Persona = listaPersonas.FirstOrDefault(p => p.Id == u.PersonaId)?.Nombre ?? "No asignado"
            }).ToList();

            dgvUsuario.DataSource = listaConNombre;
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
    }
}
