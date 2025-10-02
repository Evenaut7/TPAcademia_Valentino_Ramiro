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
        public ABMMenu()
        {
            InitializeComponent();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMmaterias materiasForm = new ABMmaterias();
            materiasForm.ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMplan planForm = new ABMplan();
            planForm.ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMEspecialidades especialidadesForm = new ABMEspecialidades();
            especialidadesForm.ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMCurso cursoForm = new ABMCurso();
            cursoForm.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMUsuario usuarioForm = new ABMUsuario();
            usuarioForm.ShowDialog();
        }

        private void alumnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ABMAlumno alumnoForm = new ABMAlumno();
            alumnoForm.ShowDialog();
        }

        private void ABMMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
