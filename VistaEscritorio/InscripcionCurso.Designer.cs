
namespace VistaEscritorio
{
    partial class InscripcionCurso : Form // Ensure the class inherits from Form
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
            dgvCursos = new DataGridView();
            btnInscribirse = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            SuspendLayout();
            // 
            // dgvCursos
            // 
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCursos.Location = new Point(42, 64);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.Size = new Size(692, 196);
            dgvCursos.TabIndex = 0;
            // 
            // btnInscribirse
            // 
            btnInscribirse.Location = new Point(659, 289);
            btnInscribirse.Name = "btnInscribirse";
            btnInscribirse.Size = new Size(75, 23);
            btnInscribirse.TabIndex = 1;
            btnInscribirse.Text = "Inscribirse";
            btnInscribirse.UseVisualStyleBackColor = true;
            btnInscribirse.Click += button1_Click;
            // 
            // InscripcionCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnInscribirse);
            Controls.Add(dgvCursos);
            Name = "InscripcionCurso";
            Text = "InscripcionCurso";
            Load += InscripcionCurso_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private DataGridView dgvCursos;
        private Button btnInscribirse;
    }
}