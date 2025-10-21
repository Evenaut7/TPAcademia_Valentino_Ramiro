using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class CargaMaterias : Form
    {
        private async Task CargarIdsAsync()
        {
            var listaPlanes = await PlanApiClient.GetAllAsync();
            idPlanBox.DataSource = listaPlanes;
            idPlanBox.DisplayMember = "Descripcion";
            idPlanBox.ValueMember = "Id";
        }

        public CargaMaterias()
        {
            InitializeComponent();
        }

        private async void agregarMateria_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(descBox.Text) ||
            string.IsNullOrWhiteSpace(horaHastaBox.Text) ||
            string.IsNullOrWhiteSpace(horaDesdeBox.Text) ||
            idPlanBox.SelectedValue == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!int.TryParse(horaDesdeBox.Text, out int hsSemanales) ||
                !int.TryParse(horaHastaBox.Text, out int hsTotales))
            {
                MessageBox.Show("Las horas deben ser números válidos.");
                return;
            }

            var nuevaMateria = new MateriaDTO
            {
                Descripcion = descBox.Text,
                HsSemanales = hsSemanales,
                HsTotales = hsTotales,
                PlanId = (int)idPlanBox.SelectedValue
            };

            try
            {
                await MateriaApiClient.AddAsync(nuevaMateria);
                MessageBox.Show("Materia agregada correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la materia: {ex.Message}");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void CargaMaterias_Load(object sender, EventArgs e)
        {
            await CargarIdsAsync();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void horaHastaBox_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
