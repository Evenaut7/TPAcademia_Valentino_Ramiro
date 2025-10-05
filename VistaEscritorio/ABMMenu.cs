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

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMProfesor());
        }

        private void Comisiones_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMComision());
        }

        private void ABMMenu_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void alumnosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new ABMAlumno());
        }
    }
}
