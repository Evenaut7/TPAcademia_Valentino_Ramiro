namespace VistaEscritorio
{
    partial class CargarCursos
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
            anioCalendarioBox = new TextBox();
            cupoBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            materiaComboBox = new ComboBox();
            comisionComboBox = new ComboBox();
            label4 = new Label();
            agregarCurso = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // anioCalendarioBox
            // 
            anioCalendarioBox.Location = new Point(107, 20);
            anioCalendarioBox.Name = "anioCalendarioBox";
            anioCalendarioBox.Size = new Size(86, 23);
            anioCalendarioBox.TabIndex = 0;
            // 
            // cupoBox
            // 
            cupoBox.Location = new Point(107, 49);
            cupoBox.Name = "cupoBox";
            cupoBox.Size = new Size(86, 23);
            cupoBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 4;
            label1.Text = "Año Calendario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 52);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 5;
            label2.Text = "Cupo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 81);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 6;
            label3.Text = "Materia";
            // 
            // materiaComboBox
            // 
            materiaComboBox.FormattingEnabled = true;
            materiaComboBox.Location = new Point(107, 78);
            materiaComboBox.Name = "materiaComboBox";
            materiaComboBox.Size = new Size(146, 23);
            materiaComboBox.TabIndex = 7;
            // 
            // comisionComboBox
            // 
            comisionComboBox.FormattingEnabled = true;
            comisionComboBox.Location = new Point(107, 107);
            comisionComboBox.Name = "comisionComboBox";
            comisionComboBox.Size = new Size(146, 23);
            comisionComboBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 110);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 9;
            label4.Text = "Comisión";
            // 
            // agregarCurso
            // 
            agregarCurso.Location = new Point(159, 159);
            agregarCurso.Name = "agregarCurso";
            agregarCurso.Size = new Size(75, 23);
            agregarCurso.TabIndex = 10;
            agregarCurso.Text = "Agregar";
            agregarCurso.UseVisualStyleBackColor = true;
            agregarCurso.Click += agregarCurso_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(240, 159);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // CargarCursos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 194);
            Controls.Add(agregarCurso);
            Controls.Add(cancelarButton);
            Controls.Add(label4);
            Controls.Add(comisionComboBox);
            Controls.Add(materiaComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cupoBox);
            Controls.Add(anioCalendarioBox);
            Name = "CargarCursos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar Curso";
            Load += CargarCursos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox anioCalendarioBox;
        private TextBox cupoBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox materiaComboBox;
        private ComboBox comisionComboBox;
        private Label label4;
        private Button agregarCurso;
        private Button cancelarButton;
    }
}