using API.Clients;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class CargaComision : Form
    {
        private List<PlanDTO>? listaPlanes;

        public CargaComision()
        {
            InitializeComponent();
        }

        private void CargarAnios()
        {
            string[] aniosValidos = { "Primero", "Segundo", "Tercero", "Cuarto", "Quinto", "Sexto" };
            anioEspecialidadBox.Items.Clear();
            anioEspecialidadBox.Items.AddRange(aniosValidos);
            anioEspecialidadBox.SelectedIndex = 0;
        }

        private async Task CargarPlanesAsync()
        {
            var planes = await PlanApiClient.GetAllAsync();
            listaPlanes = planes?.ToList();
            var especialidades = await EspecialidadApiClient.GetAllAsync();
            var listaEspecialidades = especialidades?.ToList();
            var lista = listaPlanes
                .Select(p => new
                {
                    p.Id,
                    Descripcion = $"{p.Descripcion} - {listaEspecialidades?.FirstOrDefault(e => e.Id == p.EspecialidadId)?.Descripcion}"
                })
                .ToList();
            planComboBox.DataSource = lista;
            planComboBox.DisplayMember = "Descripcion";
            planComboBox.ValueMember = "Id";
        }

        private async void CargarComision_Load(object sender, EventArgs e)
        {
            CargarAnios();
            await CargarPlanesAsync();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void agregarComision_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            var nuevaComision = new ComisionDTO
            {
                Nombre = nombreBox.Text.Trim(),
                AnioEspecialidad = anioEspecialidadBox.SelectedItem.ToString(),
                PlanId = (int)planComboBox.SelectedValue
            };

            await ComisionApiClient.AddAsync(nuevaComision);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(nombreBox.Text))
            {
                nombreBox.Focus();
                return false;
            }

            if (anioEspecialidadBox.SelectedItem == null)
            {
                anioEspecialidadBox.Focus();
                return false;
            }

            if (planComboBox.SelectedValue == null)
            {
                planComboBox.Focus();
                return false;
            }

            return true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
