using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ModificarMateria : Form
    {
        private MateriaDTO materia;

        public ModificarMateria(MateriaDTO materiaAModificar)
        {
            InitializeComponent();
            materia = materiaAModificar;
            idMateria.Text = materia.Id.ToString();
            idMateria.Enabled = false;
            descBox.Text = materia.Descripcion;
            horaDesdeBox.Text = materia.HsSemanales;
            horaHastaBox.Text = materia.HsTotales;
            idPlanBox.Text = materia.PlanId.ToString();
        }

        private async Task CargarIdsAsync()
        {
            var listaPlanes = await PlanApiClient.GetAllAsync();
            idPlanBox.DataSource = listaPlanes.Select(p => p.Id).ToList();
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

            materia.Descripcion = descBox.Text;
            materia.HsSemanales = horaDesdeBox.Text;
            materia.HsTotales = horaHastaBox.Text;
            materia.PlanId = int.Parse(idPlanBox.Text);

            try
            {
                await MateriaApiClient.UpdateAsync(materia);
                MessageBox.Show("Materia modificada correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la materia: {ex.Message}");
            }
        }

        private async void ModificarMateria_Load(object sender, EventArgs e)
        {
            await CargarIdsAsync();
        }
    }
}
