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
            btnInscribirse.Location = new Point(697, 3);
            btnInscribirse.Name = "btnInscribirse";
            btnInscribirse.Size = new Size(100, 35);
            btnInscribirse.TabIndex = 1;
            btnInscribirse.Text = "Inscribirse";
            btnInscribirse.UseVisualStyleBackColor = true;
            btnInscribirse.Click += btnInscribirse_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(btnInscribirse);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 409);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 41);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 51);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22F);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(5, 10, 5, 10);
            label1.Name = "label1";
            label1.Size = new Size(290, 41);
            label1.TabIndex = 0;
            label1.Text = "Inscripcion a Cursos ";
            // 
            // dgvCursos
            // 
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Dock = DockStyle.Fill;
            dgvCursos.Location = new Point(0, 0);
            dgvCursos.Margin = new Padding(0);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.Size = new Size(800, 358);
            dgvCursos.TabIndex = 0;
            dgvCursos.CellContentClick += dgvCursos_CellContentClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvCursos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 51);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 358);
            panel3.TabIndex = 4;
            // 
            // InscripcionCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "InscripcionCurso";
            Text = "Inscripción a Cursos";
            Load += InscripcionCurso_Load;
            panel1.ResumeLayout(false);
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
    }
}