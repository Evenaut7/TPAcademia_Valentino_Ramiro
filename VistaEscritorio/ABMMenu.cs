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

        private void materiasButton_Click(object sender, EventArgs e)
        {
            ABMmaterias materiasForm = new ABMmaterias();
            materiasForm.ShowDialog();
        }

        private void planesButton_Click(object sender, EventArgs e)
        {
            ABMplan planForm = new ABMplan();
            planForm.ShowDialog();
        }
    }
}
