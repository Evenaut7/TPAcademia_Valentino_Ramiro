using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.IO;
using API.Clients;

namespace VistaEscritorio
{
    public partial class ReporteAlumnosForm : Form
    {
        private List<CursoDTO> cursos;

        public ReporteAlumnosForm()
        {
            InitializeComponent();
            CargarCursosAsync();
        }

        private async void CargarCursosAsync()
        {
            cursos = (await CursoApiClient.GetAllAsync()).ToList();
            comboBoxCursos.DataSource = cursos;
            comboBoxCursos.DisplayMember = "Descripcion"; // O el campo que quieras mostrar
            comboBoxCursos.ValueMember = "Id";
        }

        private async void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            int cursoId = (int)comboBoxCursos.SelectedValue;
            var curso = await CursoApiClient.GetAsync(cursoId);
            var inscripciones = (await AlumnoInscripcionApiClient.GetAllAsync()).Where(i => i.CursoId == cursoId).ToList();

            var alumnos = new List<AlumnoReporte>();
            foreach (var inscripcion in inscripciones)
            {
                var usuario = await UsuarioApiClient.GetAsync(inscripcion.UsuarioId);
                var persona = await PersonaApiClient.GetAsync(usuario.PersonaId);

                alumnos.Add(new AlumnoReporte
                {
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Legajo = usuario.Legajo,
                    Nota = inscripcion.Nota,
                    Condicion = ObtenerCondicion(inscripcion.Nota)
                });
            }

            // Generar PDF
            var pdfBytes = GenerarPDF(curso, alumnos);

            // Guardar PDF
            using var sfd = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"Reporte_Alumnos_Curso_{cursoId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, pdfBytes);
                MessageBox.Show("PDF guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private byte[] GenerarPDF(CursoDTO curso, List<AlumnoReporte> alumnos)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Header().Text($"Reporte de Alumnos - Curso {curso.Id}").FontSize(18).Bold();
                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(2);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("Apellido").Bold();
                            header.Cell().Text("Nombre").Bold();
                            header.Cell().Text("Legajo").Bold();
                            header.Cell().Text("Nota").Bold();
                            header.Cell().Text("Condición").Bold();
                        });

                        foreach (var alumno in alumnos)
                        {
                            table.Cell().Text(alumno.Apellido);
                            table.Cell().Text(alumno.Nombre);
                            table.Cell().Text(alumno.Legajo);
                            table.Cell().Text(alumno.Nota?.ToString() ?? "Sin nota");
                            table.Cell().Text(alumno.Condicion);
                        }
                    });
                    page.Footer().AlignCenter().Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                });
            });

            return document.GeneratePdf();
        }

        private string ObtenerCondicion(int? nota)
        {
            if (nota is null)
                return "No cargada";
            if (nota < 6)
                return "Desaprobado";
            else
                return "Aprobado";
        }

        private class AlumnoReporte
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Legajo { get; set; }
            public int? Nota { get; set; }
            public string Condicion { get; set; }
        }

        private void ReporteAlumnosForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
