using Domain.Model;
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

            Plan nuevoPlan = new Plan
            {
                Id = Plan.ObtenerProximoId(),
                Descripcion = descBox.Text
            };

            bool resultado = await PlanNegocio.Add(nuevoPlan);
            if (resultado)
            {
                MessageBox.Show("Plan agregado correctamente.");
                Close();
            }
            else
            {
                MessageBox.Show("Error al agregar el plan.");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
