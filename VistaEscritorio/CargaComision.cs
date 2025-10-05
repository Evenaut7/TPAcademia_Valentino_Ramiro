using API.Clients; // Asumo PlanApiClient y ComisionApiClient
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class CargaComision : Form
    {
        public CargaComision()
        {
            InitializeComponent();
        }

        private async Task CargarPlanesAsync()
        {
            var listaPlanes = await PlanApiClient.GetAllAsync();
            planComboBox.DataSource = listaPlanes;
            planComboBox.DisplayMember = "Nombre"; 
            planComboBox.ValueMember = "Id";
        }

        private async void CargarComision_Load(object sender, EventArgs e)
        {
            await CargarPlanesAsync();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void agregarComision_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreBox.Text) || string.IsNullOrWhiteSpace(anioEspecialidadBox.Text) || planComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe ingresar todos los datos.");
                return;
            }
            if (!int.TryParse(anioEspecialidadBox.Text, out int anioEspecialidad))
            {
                MessageBox.Show("El Año de Especialidad debe ser un número entero.");
                return;
            }

            var nuevaComision = new DTOs.ComisionDTO
            {
                Nombre = nombreBox.Text,
                AnioEspecialidad = anioEspecialidad,
                PlanId = (int)planComboBox.SelectedValue
            };

            try
            {
                await ComisionApiClient.AddAsync(nuevaComision);
                MessageBox.Show("Comisión agregada correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la comisión: {ex.Message}");
            }
        }
    }
}