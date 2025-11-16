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
        private List<PlanDTO>? listaPlanes;

        public ModificarComision(ComisionDTO comisionAModificar)
        {
            InitializeComponent();
            comision = comisionAModificar;
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
            planComboBox.SelectedValue = comision.PlanId;
        }

        private void CargarAnios()
        {
            string[] aniosValidos = { "Primero", "Segundo", "Tercero", "Cuarto", "Quinto", "Sexto" };
            anioEspecialidadBox.Items.Clear();
            anioEspecialidadBox.Items.AddRange(aniosValidos);
        }

        private async void ModificarComision_Load(object sender, EventArgs e)
        {
            nombreBox.Text = comision.Nombre;
            CargarAnios();
            anioEspecialidadBox.SelectedItem = comision.AnioEspecialidad;
            await CargarPlanesAsync();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void modificarComision_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            comision.Nombre = nombreBox.Text.Trim();
            comision.AnioEspecialidad = anioEspecialidadBox.SelectedItem.ToString();
            comision.PlanId = (int)planComboBox.SelectedValue;

            await ComisionApiClient.UpdateAsync(comision.Id, comision);
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
    }
}
