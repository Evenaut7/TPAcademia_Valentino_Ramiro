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
    public partial class CargaMaterias : Form
    {
        public CargaMaterias()
        {
            InitializeComponent();
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
                Id = Materia.ObtenerProximoId(),
                Descripcion = descBox.Text,
                HSSemanales = horaDesdeBox.Text,
                HSTotales = horaHastaBox.Text,
                IDPlan = int.Parse(idPlanBox.Text)
            };
            bool resultado = await MateriaNegocio.Add(nuevaMateria);
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

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
