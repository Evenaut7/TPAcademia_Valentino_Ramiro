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
            btnDesuscribirse = new Button();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMisCursos).BeginInit();
            SuspendLayout();
            // 
            // dgvMisCursos
            // 
            dgvMisCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisCursos.Location = new Point(42, 64);
            dgvMisCursos.Name = "dgvMisCursos";
            dgvMisCursos.RowTemplate.Height = 25;
            dgvMisCursos.Size = new Size(716, 274);
            dgvMisCursos.TabIndex = 0;
            // 
            // btnDesuscribirse
            // 
            btnDesuscribirse.Location = new Point(683, 360);
            btnDesuscribirse.Name = "btnDesuscribirse";
            btnDesuscribirse.Size = new Size(75, 23);
            btnDesuscribirse.TabIndex = 1;
            btnDesuscribirse.Text = "Desuscribirse";
            btnDesuscribirse.UseVisualStyleBackColor = true;
            btnDesuscribirse.Click += btnDesuscribirse_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(42, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(113, 25);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Mis Cursos";
            // 
            // MisCursos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitulo);
            Controls.Add(btnDesuscribirse);
            Controls.Add(dgvMisCursos);
            Name = "MisCursos";
            Text = "Mis Cursos";
            Load += MisCursos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMisCursos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMisCursos;
        private Button btnDesuscribirse;
        private Label lblTitulo;
    }
}