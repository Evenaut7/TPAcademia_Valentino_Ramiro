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
            horaDesdeBox.Text = materia.HsSemanales.ToString();
            horaHastaBox.Text = materia.HsTotales.ToString();
        }

        private async Task CargarPlanesAsync()
        {
            try
            {
                var listaPlanes = await PlanApiClient.GetAllAsync();

                idPlanBox.DataSource = listaPlanes.ToList();
                idPlanBox.DisplayMember = "Descripcion";
                idPlanBox.ValueMember = "Id";

                // Seleccionar el plan actual
                idPlanBox.SelectedValue = materia.PlanId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los planes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void agregarMateria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descBox.Text) ||
                string.IsNullOrWhiteSpace(horaHastaBox.Text) ||
                string.IsNullOrWhiteSpace(horaDesdeBox.Text) ||
                idPlanBox.SelectedValue == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(horaDesdeBox.Text, out int hsSemanales) ||
                !int.TryParse(horaHastaBox.Text, out int hsTotales))
            {
                MessageBox.Show("Las horas deben ser números válidos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            materia.Descripcion = descBox.Text;
            materia.HsSemanales = hsSemanales;
            materia.HsTotales = hsTotales;
            materia.PlanId = (int)idPlanBox.SelectedValue;

            try
            {
                await MateriaApiClient.UpdateAsync(materia);
                MessageBox.Show("Materia modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la materia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ModificarMateria_Load(object sender, EventArgs e)
        {
            await CargarPlanesAsync();
        }
    }
}