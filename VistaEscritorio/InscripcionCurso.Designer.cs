namespace VistaEscritorio
{
    partial class InscripcionCurso : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInscribirse = new Button();
            panel1 = new Panel();
            lblEstado = new Label();
            panel2 = new Panel();
            label1 = new Label();
            dgvCursos = new DataGridView();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnInscribirse
            // 
            btnInscribirse.Dock = DockStyle.Bottom;
            btnInscribirse.Location = new Point(11, 12);
            btnInscribirse.Margin = new Padding(3, 4, 3, 4);
            btnInscribirse.Name = "btnInscribirse";
            btnInscribirse.Size = new Size(892, 47);
            btnInscribirse.TabIndex = 1;
            btnInscribirse.Text = "Inscribirse";
            btnInscribirse.UseVisualStyleBackColor = true;
            btnInscribirse.Click += btnInscribirse_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblEstado);
            panel1.Controls.Add(btnInscribirse);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 528);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(11, 13, 11, 13);
            panel1.Size = new Size(914, 72);
            panel1.TabIndex = 2;
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(15, 27);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 20);
            lblEstado.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(11, 13, 11, 13);
            panel2.Size = new Size(914, 67);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(11, 13);
            label1.Name = "label1";
            label1.Size = new Size(297, 41);
            label1.TabIndex = 0;
            label1.Text = "Inscripción a Cursos";
            // 
            // dgvCursos
            // 
            dgvCursos.AllowUserToAddRows = false;
            dgvCursos.AllowUserToDeleteRows = false;
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Dock = DockStyle.Fill;
            dgvCursos.Location = new Point(11, 13);
            dgvCursos.Margin = new Padding(3, 4, 3, 4);
            dgvCursos.MultiSelect = false;
            dgvCursos.Name = "dgvCursos";
            dgvCursos.ReadOnly = true;
            dgvCursos.RowHeadersWidth = 51;
            dgvCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCursos.Size = new Size(892, 435);
            dgvCursos.TabIndex = 0;
            dgvCursos.SelectionChanged += dgvCursos_SelectionChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvCursos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 67);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(11, 13, 11, 13);
            panel3.Size = new Size(914, 461);
            panel3.TabIndex = 4;
            // 
            // InscripcionCurso
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InscripcionCurso";
            Text = "Inscripción a Cursos";
            Load += InscripcionCurso_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnInscribirse;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private DataGridView dgvCursos;
        private Panel panel3;
        private Label lblEstado;
    }
}