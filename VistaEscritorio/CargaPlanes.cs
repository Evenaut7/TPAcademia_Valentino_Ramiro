using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class CargaPlanes : Form
    {
        private async Task CargarIdsAsync()
        {
            var listaEspecialidades = await EspecialidadApiClient.GetAllAsync();
            idEspecialidadBox.DataSource = listaEspecialidades;
            idEspecialidadBox.DisplayMember = "Descripcion";
            idEspecialidadBox.ValueMember = "Id";
        }
        public CargaPlanes()
        {
            InitializeComponent();
        }

        private async void agregarPlan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descBox.Text) || idEspecialidadBox.SelectedValue == null)
            {
                MessageBox.Show("Debe ingresar una descripción.");
                return;
            }

            var nuevoPlan = new PlanDTO
            {
                Descripcion = descBox.Text,
                EspecialidadId = (int)idEspecialidadBox.SelectedValue
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void idEspecialidadBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void CargaPlanes_Load(object sender, EventArgs e)
        {
            await CargarIdsAsync();
        }
    }
}
