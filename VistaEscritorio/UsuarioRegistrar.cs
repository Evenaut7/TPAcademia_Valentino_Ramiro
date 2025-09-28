using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class UsuarioRegistrar : Form
    {
        public UsuarioRegistrar()
        {
            InitializeComponent();
            registrarseButton.Click += registrarseButton_Click;
        }
        private async void registrarseButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(usuarioTextBox.Text) ||
                string.IsNullOrWhiteSpace(claveTextBox.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }
            var nuevoUsuario = new UsuarioDTO
            {
                Email = emailTextBox.Text,
                NombreUsuario = usuarioTextBox.Text,
                Clave = claveTextBox.Text
            };
            try
            {
                await UsuarioApiClient.AddAsync(nuevoUsuario);
                MessageBox.Show("Usuario registrado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el usuario: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsuarioRegistrar_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
