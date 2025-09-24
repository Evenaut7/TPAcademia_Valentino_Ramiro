using API.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaEscritorio
{
    public partial class CargarCursos : Form
    {
        private async Task CargarIdsAsync()
        {
            var listaMaterias = await MateriaApiClient.GetAllAsync();
            materiaComboBox.DataSource = listaMaterias;
            materiaComboBox.DisplayMember = "Descripcion";
            materiaComboBox.ValueMember = "Id";

            var listaComisiones = await ComisionApiClient.GetAllAsync();
            comisionComboBox.DataSource = listaComisiones;
            comisionComboBox.DisplayMember = "Nombre";
            comisionComboBox.ValueMember = "Id";
        }

        public CargarCursos()
        {
            InitializeComponent();
        }

        private async void CargarCursos_Load(object sender, EventArgs e)
        {
            await CargarIdsAsync();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void agregarCurso_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(anioCalendarioBox.Text) || string.IsNullOrWhiteSpace(cupoBox.Text) || materiaComboBox.SelectedValue == null || comisionComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe ingresar todos los datos.");
                return;
            }
            if (!int.TryParse(anioCalendarioBox.Text, out int anioCalendario) || !int.TryParse(cupoBox.Text, out int cupo))
            {
                MessageBox.Show("Año Calendario y Cupo deben ser números enteros.");
                return;
            }
            var nuevoCurso = new DTOs.CursoDTO
            {
                AnioCalendario = anioCalendario,
                Cupo = cupo,
                MateriaId = (int)materiaComboBox.SelectedValue,
                ComisionId = (int)comisionComboBox.SelectedValue
            };
            try
            {
                await CursoApiClient.AddAsync(nuevoCurso);
                MessageBox.Show("Curso agregado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el curso: {ex.Message}");
            }
        }
    }
}
