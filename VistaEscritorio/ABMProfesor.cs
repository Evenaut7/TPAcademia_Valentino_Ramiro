using API.Clients; 
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMProfesor : Form
    {
        private IEnumerable<ProfesorDTO>? listaProfesores;
        private IEnumerable<UsuarioDTO>? listaUsuarios; 

        public ABMProfesor()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            listaProfesores = await ProfesorApiClient.GetAllAsync();
            listaUsuarios = await UsuarioApiClient.GetAllAsync();

            var listaConNombre = listaProfesores.Select(p => new
            {
                p.Id,
                p.Nombre,
                p.Apellido, 
                p.Dni, 
                p.Cargo, 
                Usuario = listaUsuarios.FirstOrDefault(item => item.Id == p.UsuarioId)?.NombreUsuario ?? "Usuario no asignado"
            }).ToList();

            dgvProfesor.DataSource = listaConNombre;
        }

        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private async void ABMProfesor_Load(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            CargarProfesor cargarProfesor = new CargarProfesor();
            cargarProfesor.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvProfesor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para Modificar.");
                return;
            }

            int filaSeleccionada = dgvProfesor.SelectedRows[0].Index;
            if (listaProfesores == null)
            {
                MessageBox.Show("No hay profesores cargados");
                return;
            }

            var profesorAModificarDTO = listaProfesores.ToList()[filaSeleccionada];

            ModificarProfesor modificarProfesorForm = new ModificarProfesor(profesorAModificarDTO);
            modificarProfesorForm.ShowDialog();
            listarButton_Click(sender, e);
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvProfesor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }

            int filaSeleccionada = dgvProfesor.SelectedRows[0].Index;

            if (listaProfesores == null || !listaProfesores.Any())
            {
                MessageBox.Show("No hay profesores cargados.");
                return;
            }

            var profesorAEliminar = listaProfesores.ToList()[filaSeleccionada];

            try
            {
                await ProfesorApiClient.DeleteAsync(profesorAEliminar.Id);
                MessageBox.Show("Profesor eliminado correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar el profesor.");
            }
        }
    }
}