using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DTOs;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.IO;
using API.Clients;
using DrawingColor = System.Drawing.Color;

namespace VistaEscritorio
{
    public partial class ReporteAlumnosForm : Form
    {
        private List<CursoDTO> cursos;
        private List<MateriaDTO> materias;
        private List<ComisionDTO> comisiones;
        private List<AlumnoReporte> alumnosReporte;
        private CursoDTO cursoSeleccionado;
        private List<CursoItem> cursoItems;

        public ReporteAlumnosForm()
        {
            InitializeComponent();
            BackColor = DrawingColor.White;
            Font = new Font("Segoe UI", 10);
            Load += ReporteAlumnosForm_Load;
        }

        private async void ReporteAlumnosForm_Load(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            var t1 = CursoApiClient.GetAllAsync();
            var t2 = MateriaApiClient.GetAllAsync();
            var t3 = ComisionApiClient.GetAllAsync();
            await Task.WhenAll(t1, t2, t3);
            cursos = (await t1).ToList();
            materias = (await t2).ToList();
            comisiones = (await t3).ToList();

            cursoItems = cursos.Select(c =>
            {
                var mat = materias.FirstOrDefault(m => m.Id == c.MateriaId)?.Descripcion ?? $"ID {c.MateriaId}";
                var com = comisiones.FirstOrDefault(x => x.Id == c.ComisionId)?.Nombre ?? $"ID {c.ComisionId}";
                return new CursoItem { Id = c.Id, Display = $"[{mat}] - {com} - {c.AnioCalendario}", Curso = c };
            }).ToList();

            comboBoxCursos.DataSource = new BindingSource(cursoItems, null);
            comboBoxCursos.DisplayMember = "Display";
            comboBoxCursos.ValueMember = "Id";
            comboBoxCursos.SelectedIndex = -1;
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (comboBoxCursos.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un curso válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnGenerarReporte.Enabled = false;
            btnDescargarPDF.Enabled = false;
            labelCargando.Visible = true;
            labelCargando.Text = "Cargando alumnos...";

            int cursoId = (int)comboBoxCursos.SelectedValue;
            cursoSeleccionado = cursos.FirstOrDefault(c => c.Id == cursoId) ?? await CursoApiClient.GetAsync(cursoId);

            var inscripciones = (await AlumnoInscripcionApiClient.GetAllAsync())
                .Where(i => i.CursoId == cursoId).ToList();

            alumnosReporte = new List<AlumnoReporte>();
            var usuarioTasks = inscripciones.Select(i => UsuarioApiClient.GetAsync(i.UsuarioId)).ToArray();
            var usuarios = (await Task.WhenAll(usuarioTasks)).ToDictionary(u => u.Id);
            var personaTasks = usuarios.Values.Select(u => PersonaApiClient.GetAsync(u.PersonaId)).ToArray();
            var personas = (await Task.WhenAll(personaTasks)).ToDictionary(p => p.Id);

            foreach (var ins in inscripciones)
            {
                var usuario = usuarios[ins.UsuarioId];
                var persona = personas[usuario.PersonaId];
                alumnosReporte.Add(new AlumnoReporte
                {
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Legajo = usuario.Legajo,
                    Nota = ins.Nota,
                    Condicion = ObtenerCondicion(ins.Nota)
                });
            }

            alumnosReporte = alumnosReporte.OrderBy(a => a.Apellido).ThenBy(a => a.Nombre).ToList();
            lblTotalAlumnos.Text = $"Total: {alumnosReporte.Count}";
            dataGridViewAlumnos.RowCount = alumnosReporte.Count;
            dataGridViewAlumnos.Invalidate();
            btnDescargarPDF.Enabled = alumnosReporte.Count > 0;
            labelCargando.Visible = false;
            btnGenerarReporte.Enabled = true;
        }

        private void dataGridViewAlumnos_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (alumnosReporte == null || e.RowIndex < 0 || e.RowIndex >= alumnosReporte.Count) return;
            var a = alumnosReporte[e.RowIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = (e.RowIndex + 1).ToString();
                    break;
                case 1:
                    e.Value = a.Apellido;
                    break;
                case 2:
                    e.Value = a.Nombre;
                    break;
                case 3:
                    e.Value = a.Legajo;
                    break;
                case 4:
                    e.Value = a.Nota.HasValue ? a.Nota.Value.ToString("F1") : "Sin";
                    break;
                case 5:
                    e.Value = a.Condicion;
                    break;
            }
        }

        private async void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            if (alumnosReporte == null || alumnosReporte.Count == 0)
            {
                MessageBox.Show("Genere el reporte primero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnDescargarPDF.Enabled = false;
            labelCargando.Visible = true;
            labelCargando.Text = "Generando PDF...";

            var matDesc = materias?.FirstOrDefault(m => m.Id == cursoSeleccionado.MateriaId)?.Descripcion ?? $"ID {cursoSeleccionado.MateriaId}";
            var comDesc = comisiones?.FirstOrDefault(c => c.Id == cursoSeleccionado.ComisionId)?.Nombre ?? $"ID {cursoSeleccionado.ComisionId}";
            var pdf = GenerarPDF(cursoSeleccionado, matDesc, comDesc, alumnosReporte);

            using var sfd = new SaveFileDialog();
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            sfd.FileName = $"Reporte_Alumnos_Curso_{cursoSeleccionado.Id}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, pdf);
                MessageBox.Show("PDF guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            labelCargando.Visible = false;
            btnDescargarPDF.Enabled = true;
        }

        private byte[] GenerarPDF(CursoDTO curso, string materiaDescripcion, string comisionNombre, List<AlumnoReporte> alumnos)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Header().Element(header =>
                    {
                        header.Column(col =>
                        {
                            col.Item().Text("REPORTE DE ALUMNOS INSCRITOS").FontSize(16).Bold().FontColor("1f2937");
                            col.Spacing(6);
                            col.Item().Text($"Curso: {curso.Id}   Materia: {materiaDescripcion}   Comisión: {comisionNombre}").FontSize(10);
                            col.Item().Text($"Año: {curso.AnioCalendario}   Cupo: {curso.Cupo}").FontSize(10);
                            col.Spacing(8);
                        });
                    });
                    page.Content().Element(content =>
                    {
                        content.Column(col =>
                        {
                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(def =>
                                {
                                    def.RelativeColumn(0.5f);
                                    def.RelativeColumn(2f);
                                    def.RelativeColumn(2f);
                                    def.RelativeColumn(1.5f);
                                    def.RelativeColumn(1f);
                                    def.RelativeColumn(1.5f);
                                });

                                table.Header(headerRow =>
                                {
                                    headerRow.Cell().Background("1f2937").Padding(6).Text("Nº").FontColor("ffffff").Bold().FontSize(9);
                                    headerRow.Cell().Background("1f2937").Padding(6).Text("Apellido").FontColor("ffffff").Bold().FontSize(9);
                                    headerRow.Cell().Background("1f2937").Padding(6).Text("Nombre").FontColor("ffffff").Bold().FontSize(9);
                                    headerRow.Cell().Background("1f2937").Padding(6).Text("Legajo").FontColor("ffffff").Bold().FontSize(9);
                                    headerRow.Cell().Background("1f2937").Padding(6).AlignCenter().Text("Nota").FontColor("ffffff").Bold().FontSize(9);
                                    headerRow.Cell().Background("1f2937").Padding(6).AlignCenter().Text("Condición").FontColor("ffffff").Bold().FontSize(9);
                                });

                                int num = 1;
                                foreach (var a in alumnos)
                                {
                                    var bg = num % 2 == 0 ? "f3f4f6" : "ffffff";
                                    table.Cell().Background(bg).Padding(6).Text(num.ToString()).FontSize(9);
                                    table.Cell().Background(bg).Padding(6).Text(a.Apellido).FontSize(9);
                                    table.Cell().Background(bg).Padding(6).Text(a.Nombre).FontSize(9);
                                    table.Cell().Background(bg).Padding(6).Text(a.Legajo).FontSize(9);
                                    table.Cell().Background(bg).Padding(6).AlignCenter().Text(a.Nota.HasValue ? a.Nota.Value.ToString("F1") : "Sin nota").FontSize(9);
                                    var colorCond = ObtenerColorCondicionPDF(a.Condicion);
                                    table.Cell().Background(colorCond).Padding(6).AlignCenter().Text(a.Condicion).FontSize(9).Bold();
                                    num++;
                                }
                            });

                            col.Spacing(12);

                            var aprobados = alumnos.Count(x => x.Condicion == "Aprobado");
                            var desaprobados = alumnos.Count(x => x.Condicion == "Desaprobado");
                            var sinNota = alumnos.Count(x => x.Condicion == "Sin Nota");
                            var notaPromedio = alumnos.Where(a => a.Nota.HasValue).Any() ? alumnos.Where(a => a.Nota.HasValue).Average(a => a.Nota.Value) : 0;

                            col.Item().BorderTop(1).BorderColor("e5e7eb").PaddingTop(12).Row(r =>
                            {
                                r.RelativeColumn().Column(c =>
                                {
                                    c.Item().Text($"Aprobados: {aprobados}").Bold();
                                    c.Item().Text($"Sin nota: {sinNota}").Bold();
                                });
                                r.RelativeColumn().Column(c =>
                                {
                                    c.Item().Text($"Desaprobados: {desaprobados}").Bold();
                                    c.Item().Text($"Nota Promedio: {notaPromedio:F2}").Bold();
                                });
                            });
                        });
                    });
                    page.Footer().Element(f => f.AlignCenter().Text($"Documento generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}"));
                });
            });

            return document.GeneratePdf();
        }

        private string ObtenerColorCondicionPDF(string condicion)
        {
            return condicion switch
            {
                "Aprobado" => "d1fae5",
                "Desaprobado" => "fee2e2",
                "Sin Nota" => "fed7aa",
                _ => "ffffff"
            };
        }

        private string ObtenerCondicion(int? nota)
        {
            if (!nota.HasValue) return "Sin Nota";
            if (nota.Value < 6) return "Desaprobado";
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

        private class CursoItem
        {
            public int Id { get; set; }
            public string Display { get; set; }
            public CursoDTO Curso { get; set; }
        }
    }
}
