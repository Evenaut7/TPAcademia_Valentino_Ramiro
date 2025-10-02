using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ABMAlumno : Form
    {
        private IEnumerable<AlumnoDTO>? listaAlumnos;

        public ABMAlumno()
        {
            InitializeComponent();
        }

        private async Task CargarTablaAsync()
        {
            listaAlumnos = await AlumnoApiClient.GetAllAsync();
            dgvAlumnos.DataSource = listaAlumnos
                .Select(a => new
                {
                    a.Id,
                    a.Nombre,
                    a.Apellido,
                    a.Dni,
                    a.FechaNacimiento,
                    a.Legajo,
                    Usuario = a.Usuario == null ? "Sin usuario" : a.Usuario.NombreUsuario
                }).ToList();
        }

        private async void listarButton_Click(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            AlumnoRegistrar alumnoRegistrar = new AlumnoRegistrar();
            alumnoRegistrar.ShowDialog();
            listarButton_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para modificar.");
                return;
            }
            int filaSeleccionada = dgvAlumnos.SelectedRows[0].Index;
            if (listaAlumnos == null)
            {
                MessageBox.Show("No hay alumnos cargados.");
                return;
            }
            var alumnoAModificar = listaAlumnos.ToList()[filaSeleccionada];
            ModificarAlumno modificarAlumnoForm = new ModificarAlumno(alumnoAModificar);
            modificarAlumnoForm.ShowDialog();
            listarButton_Click(sender, e);
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.");
                return;
            }
            int filaSeleccionada = dgvAlumnos.SelectedRows[0].Index;
            if (listaAlumnos == null)
            {
                MessageBox.Show("No hay alumnos cargados.");
                return;
            }
            var alumnoAEliminar = listaAlumnos.ToList()[filaSeleccionada];
            try
            {
                await AlumnoApiClient.DeleteAsync(alumnoAEliminar.Id);
                MessageBox.Show("Alumno eliminado correctamente.");
                await CargarTablaAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar el alumno.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void ABMAlumno_Load_1(object sender, EventArgs e)
        {
            await CargarTablaAsync();
        }
    }
}