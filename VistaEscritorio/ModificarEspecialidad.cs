using API.Clients;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ModificarEspecialidad : Form
    {
        private EspecialidadDTO especialidad;
        private void CargarDatos()
        {
            descText.Text = especialidad.Descripcion;
        }
        public ModificarEspecialidad(EspecialidadDTO especialidadSeleccionada)
        {
            InitializeComponent();
            especialidad = especialidadSeleccionada;
            CargarDatos();
        }

        public void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void aceptarButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descText.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.");
                return;
            }
            else
            {
                especialidad.Descripcion = descText.Text;
                try
                {
                    await EspecialidadApiClient.UpdateAsync(especialidad);
                    MessageBox.Show("Especialidad modificada correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar la especialidad: {ex.Message}");
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void descText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
