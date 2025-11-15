using API.Clients; 
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class ModificarComision : Form
    {
        private ComisionDTO comision;

        public ModificarComision(ComisionDTO comisionAModificar)
        {
            InitializeComponent();
            comision = comisionAModificar;
            nombreBox.Text = comision.Nombre;
            anioEspecialidadBox.Text = comision.AnioEspecialidad.ToString();
        }

        private async Task CargarPlanesAsync()
        {
            var listaPlanes = await PlanApiClient.GetAllAsync();
            planComboBox.DataSource = listaPlanes;
            planComboBox.DisplayMember = "Nombre";
            planComboBox.ValueMember = "Id";

            planComboBox.SelectedValue = comision.PlanId;
        }

        private async void ModificarComision_Load(object sender, EventArgs e)
        {
            await CargarPlanesAsync();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void modificarComision_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreBox.Text) || string.IsNullOrWhiteSpace(anioEspecialidadBox.Text) || planComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe ingresar todos los datos.");
                return;
            }

            comision.Nombre = nombreBox.Text;
            comision.AnioEspecialidad = anioEspecialidadBox.Text;
            comision.PlanId = (int)planComboBox.SelectedValue;

            try
            {
                await ComisionApiClient.UpdateAsync(comision.Id, comision);
                MessageBox.Show("Comisión modificada correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la comisión: {ex.Message}");
            }
        }
    }
}