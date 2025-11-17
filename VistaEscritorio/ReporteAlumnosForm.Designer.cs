namespace VistaEscritorio
{
    partial class ReporteAlumnosForm
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
            btnDescargarPDF = new Button();
            comboBoxCursos = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnDescargarPDF
            // 
            btnDescargarPDF.Location = new Point(210, 208);
            btnDescargarPDF.Name = "btnDescargarPDF";
            btnDescargarPDF.Size = new Size(167, 50);
            btnDescargarPDF.TabIndex = 0;
            btnDescargarPDF.Text = "Descargar Reporte";
            btnDescargarPDF.UseVisualStyleBackColor = true;
            btnDescargarPDF.Click += btnDescargarPDF_Click;
            // 
            // comboBoxCursos
            // 
            comboBoxCursos.FormattingEnabled = true;
            comboBoxCursos.Location = new Point(210, 157);
            comboBoxCursos.Name = "comboBoxCursos";
            comboBoxCursos.Size = new Size(167, 23);
            comboBoxCursos.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(210, 140);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 2;
            label1.Text = "Seleccione el ID del Curso";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(210, 27);
            label2.Name = "label2";
            label2.Size = new Size(154, 45);
            label2.TabIndex = 3;
            label2.Text = "Reportes";
            // 
            // ReporteAlumnosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 339);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxCursos);
            Controls.Add(btnDescargarPDF);
            Name = "ReporteAlumnosForm";
            Text = "ReporteAlumnosForm";
            Load += ReporteAlumnosForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDescargarPDF;
        private ComboBox comboBoxCursos;
        private Label label1;
        private Label label2;
    }
}