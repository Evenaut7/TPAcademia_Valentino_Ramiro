using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class CargaPlanes : Form
    {
        public CargaPlanes()
        {
            InitializeComponent();
        }

        private async void agregarPlan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descBox.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.");
                return;
            }

            var nuevoPlan = new PlanDTO
            {
                Descripcion = descBox.Text
                // El Id lo asigna el backend
            };

            try
            {
                await PlanApiClient.AddAsync(nuevoPlan);
                MessageBox.Show("Plan agregado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el plan: {ex.Message}");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
