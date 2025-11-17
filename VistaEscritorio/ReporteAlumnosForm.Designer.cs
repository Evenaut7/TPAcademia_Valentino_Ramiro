using System.Drawing;
using DrawingColor = System.Drawing.Color;

namespace VistaEscritorio
{
    partial class ReporteAlumnosForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panelSeleccion;
        private System.Windows.Forms.Label labelSeleccione;
        private System.Windows.Forms.ComboBox comboBoxCursos;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Panel panelDescargar;
        private System.Windows.Forms.Button btnDescargarPDF;
        private System.Windows.Forms.Label labelCargando;
        private System.Windows.Forms.Label lblTotalAlumnos;
        private System.Windows.Forms.Panel panelReporte;
        private System.Windows.Forms.DataGridView dataGridViewAlumnos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            labelTitulo = new System.Windows.Forms.Label();
            panelSeleccion = new System.Windows.Forms.Panel();
            labelSeleccione = new System.Windows.Forms.Label();
            comboBoxCursos = new System.Windows.Forms.ComboBox();
            btnGenerarReporte = new System.Windows.Forms.Button();
            panelDescargar = new System.Windows.Forms.Panel();
            btnDescargarPDF = new System.Windows.Forms.Button();
            labelCargando = new System.Windows.Forms.Label();
            lblTotalAlumnos = new System.Windows.Forms.Label();
            panelReporte = new System.Windows.Forms.Panel();
            dataGridViewAlumnos = new System.Windows.Forms.DataGridView();

            SuspendLayout();

            labelTitulo.AutoSize = true;
            labelTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            labelTitulo.Location = new System.Drawing.Point(16, 12);
            labelTitulo.Text = "Reportes";

            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Height = 56;
            panelHeader.BackColor = DrawingColor.White;
            panelHeader.Controls.Add(labelTitulo);

            labelSeleccione.AutoSize = true;
            labelSeleccione.Font = new System.Drawing.Font("Segoe UI", 10F);
            labelSeleccione.Location = new System.Drawing.Point(16, 12);
            labelSeleccione.Text = "Seleccionar Curso";

            comboBoxCursos.Font = new System.Drawing.Font("Segoe UI", 10F);
            comboBoxCursos.Location = new System.Drawing.Point(16, 36);
            comboBoxCursos.Width = 520;
            comboBoxCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            btnGenerarReporte.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGenerarReporte.Location = new System.Drawing.Point(548, 34);
            btnGenerarReporte.Size = new System.Drawing.Size(120, 30);
            btnGenerarReporte.Text = "Generar";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            btnGenerarReporte.Click += btnGenerarReporte_Click;

            panelSeleccion.Dock = System.Windows.Forms.DockStyle.Top;
            panelSeleccion.Height = 80;
            panelSeleccion.Padding = new System.Windows.Forms.Padding(8);
            panelSeleccion.Controls.Add(labelSeleccione);
            panelSeleccion.Controls.Add(comboBoxCursos);
            panelSeleccion.Controls.Add(btnGenerarReporte);

            btnDescargarPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDescargarPDF.Location = new System.Drawing.Point(16, 12);
            btnDescargarPDF.Size = new System.Drawing.Size(160, 32);
            btnDescargarPDF.Text = "Descargar PDF";
            btnDescargarPDF.UseVisualStyleBackColor = true;
            btnDescargarPDF.Enabled = false;
            btnDescargarPDF.Click += btnDescargarPDF_Click;

            labelCargando.AutoSize = true;
            labelCargando.Font = new System.Drawing.Font("Segoe UI", 9F);
            labelCargando.Location = new System.Drawing.Point(192, 18);
            labelCargando.Text = "Cargando...";
            labelCargando.Visible = false;

            lblTotalAlumnos.AutoSize = true;
            lblTotalAlumnos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTotalAlumnos.Location = new System.Drawing.Point(320, 17);
            lblTotalAlumnos.Text = "Total: 0";

            panelDescargar.Dock = System.Windows.Forms.DockStyle.Top;
            panelDescargar.Height = 60;
            panelDescargar.Padding = new System.Windows.Forms.Padding(12);
            panelDescargar.Controls.Add(btnDescargarPDF);
            panelDescargar.Controls.Add(labelCargando);
            panelDescargar.Controls.Add(lblTotalAlumnos);

            dataGridViewAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewAlumnos.AllowUserToAddRows = false;
            dataGridViewAlumnos.AllowUserToDeleteRows = false;
            dataGridViewAlumnos.ReadOnly = true;
            dataGridViewAlumnos.RowHeadersVisible = false;
            dataGridViewAlumnos.VirtualMode = true;
            dataGridViewAlumnos.BackgroundColor = DrawingColor.White;
            dataGridViewAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAlumnos.CellValueNeeded += dataGridViewAlumnos_CellValueNeeded;

            var colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNumero.HeaderText = "Nº";
            colNumero.Width = 50;
            colNumero.Name = "colNumero";
            var colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colApellido.HeaderText = "Apellido";
            colApellido.Width = 200;
            colApellido.Name = "colApellido";
            var colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNombre.HeaderText = "Nombre";
            colNombre.Width = 200;
            colNombre.Name = "colNombre";
            var colLegajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLegajo.HeaderText = "Legajo";
            colLegajo.Width = 120;
            colLegajo.Name = "colLegajo";
            var colNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNota.HeaderText = "Nota";
            colNota.Width = 70;
            colNota.Name = "colNota";
            var colCondicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCondicion.HeaderText = "Condición";
            colCondicion.Width = 120;
            colCondicion.Name = "colCondicion";

            dataGridViewAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colNumero, colApellido, colNombre, colLegajo, colNota, colCondicion
            });

            panelReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            panelReporte.AutoScroll = true;
            panelReporte.Padding = new System.Windows.Forms.Padding(12);
            panelReporte.Controls.Add(dataGridViewAlumnos);

            ClientSize = new System.Drawing.Size(920, 650);
            Controls.Add(panelReporte);
            Controls.Add(panelDescargar);
            Controls.Add(panelSeleccion);
            Controls.Add(panelHeader);
            Name = "ReporteAlumnosForm";
            Text = "Reporte de Alumnos";

            ResumeLayout(false);
        }
    }
}
