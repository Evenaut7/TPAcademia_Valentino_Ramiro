using API.Clients;
using DTOs;
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
    public partial class CargaEspecialidades : Form
    {
        public CargaEspecialidades()
        {
            InitializeComponent();
        }
        private void clancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void agregarEspecialidad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descText.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.");
                return;
            }

            var nuevaEspecialidad = new EspecialidadDTO
            {
                Descripcion = descText.Text,
            };

            try
            {
                await EspecialidadApiClient.AddAsync(nuevaEspecialidad);
                MessageBox.Show("Especialidad agregado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la Especialidad: {ex.Message}");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
