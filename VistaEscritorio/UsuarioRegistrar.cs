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
using Domain.Model;
using Data; // O el namespace donde esté tu repositorio de personas

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

            int personaId = (int)personaComboBox.SelectedValue;

            var nuevoUsuario = new UsuarioDTO
            {
                Email = emailTextBox.Text,
                NombreUsuario = usuarioTextBox.Text,
                Clave = claveTextBox.Text,
                PersonaId = personaId
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
            var alumnoRepository = new AlumnoRepository();
            var profesorRepository = new ProfesorRepository();

            // Obtén todos los alumnos y profesores
            var alumnos = alumnoRepository.GetAll().ToList();
            var profesores = profesorRepository.GetAll().ToList();

            // Combina ambas listas en una sola lista de Persona
            var personas = new List<Persona>();
            personas.AddRange(alumnos);
            personas.AddRange(profesores);

            personaComboBox.DataSource = personas;
            personaComboBox.DisplayMember = "Dni"; // Muestra el DNI
            personaComboBox.ValueMember = "Id";    // El valor seleccionado será el Id
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
