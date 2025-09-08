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
            // Usar el cliente API para obtener los planes
            var listaPlanes = await PlanApiClient.GetAllAsync();
            idPlanBox.DataSource = listaPlanes.Select(p => p.Id).ToList();
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
                string.IsNullOrWhiteSpace(idPlanBox.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            var nuevaMateria = new MateriaDTO
            {
                // El Id lo asigna el backend, así que lo dejamos en 0
                Descripcion = descBox.Text,
                HsSemanales = horaDesdeBox.Text,
                HsTotales = horaHastaBox.Text,
                PlanId = int.Parse(idPlanBox.Text)
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
    }
}
