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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            nuevaCuentaButton.Click += nuevaCuentaButton_Click;

        }

        private void nuevaCuentaButton_Click(object sender, EventArgs e)
        {
            UsuarioRegistrar usuarioRegistrar = new UsuarioRegistrar();
            usuarioRegistrar.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
