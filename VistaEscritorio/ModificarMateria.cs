using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

using Negocio;
namespace VistaEscritorio
{
    public partial class ModificarMateria : Form
    {
        public ModificarMateria(Materia materiaAModificar)
        {
            InitializeComponent();
            idMateria.Text = materiaAModificar.Id.ToString();
            idMateria.Enabled = false;
            descBox.Text = materiaAModificar.Descripcion;
            horaDesdeBox.Text = materiaAModificar.HSSemanales;
            horaHastaBox.Text = materiaAModificar.HSTotales;
            idPlanBox.Text = materiaAModificar.IDPlan.ToString();

        }

        private async void agregarMateria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descBox.Text) ||
                string.IsNullOrWhiteSpace(horaHastaBox.Text) || string.IsNullOrWhiteSpace(horaDesdeBox.Text) ||
                string.IsNullOrWhiteSpace(idPlanBox.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }
            Materia nuevaMateria = new Materia
            {
                Id = int.Parse(idMateria.Text),
                Descripcion = descBox.Text,
                HSSemanales = horaDesdeBox.Text,
                HSTotales = horaHastaBox.Text,
                IDPlan = int.Parse(idPlanBox.Text)
            };
            bool resultado = await MateriaNegocio.Update(nuevaMateria);
            if (resultado)
            {
                MessageBox.Show("Materia agregada correctamente.");
                Close();
            }
            else
            {
                MessageBox.Show("Error al agregar la materia.");
            }
        }
    }
}
