namespace VistaEscritorio
{
    partial class ABMAlumno
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvAlumnos;
        private Button listarButton;
        private Button agregarButton;
        private Button eliminarButton;
        private Button modificarButton;
        private Panel panel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvAlumnos = new DataGridView();
            panel1 = new Panel();
            listarButton = new Button();
            agregarButton = new Button();
            eliminarButton = new Button();
            modificarButton = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();

            // dgvAlumnos
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnos.Dock = DockStyle.Top;
            dgvAlumnos.Location = new Point(0, 0);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.Size = new Size(680, 150);
            dgvAlumnos.TabIndex = 0;

            // panel1
            panel1.Controls.Add(listarButton);
            panel1.Controls.Add(agregarButton);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(eliminarButton);
            panel1.Location = new Point(335, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(329, 40);
            panel1.TabIndex = 3;

            // listarButton
            listarButton.Dock = DockStyle.Right;
            listarButton.Text = "Listar";
            listarButton.Click += listarButton_Click;

            // agregarButton
            agregarButton.Dock = DockStyle.Right;
            agregarButton.Text = "Agregar";
            agregarButton.Click += agregarButton_Click;

            // modificarButton
            modificarButton.Dock = DockStyle.Right;
            modificarButton.Text = "Modificar";
            modificarButton.Click += modificarButton_Click;

            // eliminarButton
            eliminarButton.Dock = DockStyle.Right;
            eliminarButton.Text = "Eliminar";
            eliminarButton.Click += eliminarButton_Click;

            // AlumnoABM
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 244);
            Controls.Add(panel1);
            Controls.Add(dgvAlumnos);
            Name = "AlumnoABM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ABM Alumnos";
            Load += AlumnoABM_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}