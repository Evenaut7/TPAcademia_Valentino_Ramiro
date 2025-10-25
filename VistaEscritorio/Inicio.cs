using System;
using System.Windows.Forms;
using Application.Services;
using API.Clients;

namespace VistaEscritorio
{
    public partial class Inicio : Form
    {

        public Inicio()
        {
            InitializeComponent();
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

                // ✅ Autenticar a través del AuthServiceProvider
                bool response = await AuthServiceProvider.Instance.LoginAsync(usuario, clave);
                if (response)
                {
                    MessageBox.Show("Inicio de sesión exitoso.");

                    this.DialogResult = DialogResult.OK;
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

        private void nuevaCuentaButton_Click(object sender, EventArgs e)
        {
            var usuarioRegistrar = new CargarUsuario();
            usuarioRegistrar.ShowDialog();
        }
    }
}
