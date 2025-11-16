namespace VistaEscritorio
{
    partial class MisCursos : Form
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
            dgvMisCursos = new DataGridView();
            lblTitulo = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            btnDesuscribirse = new Button();
            lblEstado = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvMisCursos).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMisCursos
            // 
            dgvMisCursos.AllowUserToAddRows = false;
            dgvMisCursos.AllowUserToDeleteRows = false;
            dgvMisCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisCursos.Dock = DockStyle.Fill;
            dgvMisCursos.Location = new Point(11, 13);
            dgvMisCursos.Margin = new Padding(3, 4, 3, 4);
            dgvMisCursos.MultiSelect = false;
            dgvMisCursos.Name = "dgvMisCursos";
            dgvMisCursos.ReadOnly = true;
            dgvMisCursos.RowHeadersWidth = 51;
            dgvMisCursos.RowTemplate.Height = 25;
            dgvMisCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMisCursos.Size = new Size(892, 431);
            dgvMisCursos.TabIndex = 0;
            dgvMisCursos.SelectionChanged += dgvMisCursos_SelectionChanged;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(11, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(238, 41);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Cursos Actuales";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(lblTitulo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(11, 13, 11, 13);
            panel1.Size = new Size(914, 67);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvMisCursos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 67);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(11, 13, 11, 13);
            panel3.Size = new Size(914, 457);
            panel3.TabIndex = 5;
            // 
            // btnDesuscribirse
            // 
            btnDesuscribirse.Dock = DockStyle.Bottom;
            btnDesuscribirse.Location = new Point(11, 16);
            btnDesuscribirse.Margin = new Padding(0);
            btnDesuscribirse.Name = "btnDesuscribirse";
            btnDesuscribirse.Size = new Size(892, 47);
            btnDesuscribirse.TabIndex = 1;
            btnDesuscribirse.Text = "Desuscribirse";
            btnDesuscribirse.UseVisualStyleBackColor = true;
            btnDesuscribirse.Click += btnDesuscribirse_Click;
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(15, 31);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 20);
            lblEstado.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblEstado);
            panel2.Controls.Add(btnDesuscribirse);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 524);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(11, 13, 11, 13);
            panel2.Size = new Size(914, 76);
            panel2.TabIndex = 4;
            // 
            // MisCursos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MisCursos";
            Text = "Cursos Actuales";
            Load += MisCursos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMisCursos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMisCursos;
        private Label lblTitulo;
        private Panel panel1;
        private Panel panel3;
        private Button btnDesuscribirse;
        private Label lblEstado;
        private Panel panel2;
    }
}