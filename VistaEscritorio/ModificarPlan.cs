using System;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ModificarPlan : Form
    {
        private PlanDTO plan;

        public ModificarPlan(PlanDTO planSeleccionado)
        {
            InitializeComponent();
            plan = planSeleccionado;
            CargarDatos();
        }

        private void CargarDatos()
        {
            idBox.Text = plan.Id.ToString();
            descBox.Text = plan.Descripcion;
        }

        private async void modificarPlan_Click(object sender, EventArgs e)
        {
            plan.Descripcion = descBox.Text;

            try
            {
                await PlanApiClient.UpdateAsync(plan);
                MessageBox.Show("Plan modificado correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el plan: {ex.Message}");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
