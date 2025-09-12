using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Clients;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = usuarioTextBox.Text;
                string clave = passwordTextBox.Text;
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
                {
                    MessageBox.Show("Por favor, ingrese usuario y clave.");
                    return;
                }
                bool response = await UsuarioApiClient.ValidarUsuario(usuario, clave);
                if (response)
                {
                    MessageBox.Show("Inicio de sesión exitoso.");
                    this.Hide();
                    ABMMenu mainForm = new ABMMenu();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o clave incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}");
            }
        }
    }
}
