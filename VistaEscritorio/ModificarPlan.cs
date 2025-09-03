using System;
using System.Windows.Forms;
using Domain.Model;

namespace VistaEscritorio
{
    public partial class ModificarPlan : Form
    {
        private Plan plan;

        public ModificarPlan(Plan planSeleccionado)
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

            var exito = await PlanNegocio.Update(plan);
            if (exito)
            {
                MessageBox.Show("Plan modificado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al modificar el plan");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
