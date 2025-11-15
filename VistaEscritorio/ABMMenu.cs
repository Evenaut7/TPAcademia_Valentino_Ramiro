using API.Clients;
using Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ABMMenu : Form
    {
        private string? _username;

        public ABMMenu()
        {
            InitializeComponent();
        }
        public async Task CargarDatosUsuarioAsync()
        {
            var username = await AuthServiceProvider.Instance.GetUsernameAsync();
            if (username == null)
            {
                MessageBox.Show("No hay usuario autenticado.");
                return;
            }

            _username = username;
            this.Text = $"Menú principal - {username}";
        }

        private async void ABMMenu_Load(object sender, EventArgs e)
        {
            await CargarDatosUsuarioAsync();

            try
            {
                int usuarioId = await AuthServiceProvider.Instance.GetUserIdAsync();

                if (usuarioId == 0)
                {
                    MessageBox.Show("No hay usuario autenticado.");
                    Close();
                    return;
                }

                string rol = await UsuarioApiClient.getUserRole(usuarioId);

                switch (rol)
                {
                    case "Administrador":
                        ConfigurarMenuAdministrador();
                        break;
                    case "Alumno":
                        ConfigurarMenuAlumno();
                        break;
                    case "Profesor":
                        MessageBox.Show("Rol en progreso");
                        Close();
                        break;
                    default:
                        MessageBox.Show("Rol no reconocido");
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el menú: {ex.Message}");
                Close();
            }
        }

        private void AbrirFormularioEnPanel(Form formHijo)
        {
            if (ABMPanel.Controls.Count > 0)
                ABMPanel.Controls.RemoveAt(0);

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            ABMPanel.Controls.Add(formHijo);
            ABMPanel.Tag = formHijo;

            formHijo.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMmaterias());
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMplan());
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMEspecialidades());
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMCurso());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMUsuario());
        }

        private void Comisiones_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMComision());
        }
        private void ConfigurarMenuAdministrador()
        {
            menuStrip1.Visible = true;
            inscripcionCursoToolStripMenu.Visible = false;
            cursosActualesToolStripMenu.Visible = false;
        }

        private void ConfigurarMenuAlumno()
        {
            menuStrip1.Visible = true;
            inscripcionCursoToolStripMenu.Visible = true;
            cursosActualesToolStripMenu.Visible = true;
            materiasToolStripMenuItem.Visible = false;
            planesToolStripMenuItem.Visible = false;
            especialidadesToolStripMenuItem.Visible = false;
            Comisiones.Visible = false;
            cursosToolStripMenuItem.Visible = false;
            usuariosToolStripMenuItem.Visible = false;
            alumnosToolStripMenuItem.Visible = false;
        }

        private void ConfigurarMenuProfesor()
        {
            // Mostrar solo las opciones para profesores
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void alumnosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMPersona());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cursosActualesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ABMPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inscripcionCursoToolStripMenu_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new InscripcionCurso());
        }

        private void cursosActualesToolStripMenu_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new MisCursos());
        }
    }
}
