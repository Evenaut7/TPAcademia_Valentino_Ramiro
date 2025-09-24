namespace VistaEscritorio
{
    partial class ModificarCurso
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
            agregarCurso = new Button();
            cancelarButton = new Button();
            label4 = new Label();
            comisionComboBox = new ComboBox();
            materiaComboBox = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cupoBox = new TextBox();
            anioCalendarioBox = new TextBox();
            SuspendLayout();
            // 
            // agregarCurso
            // 
            agregarCurso.Location = new Point(158, 151);
            agregarCurso.Name = "agregarCurso";
            agregarCurso.Size = new Size(75, 23);
            agregarCurso.TabIndex = 20;
            agregarCurso.Text = "Agregar";
            agregarCurso.UseVisualStyleBackColor = true;
            agregarCurso.Click += agregarCurso_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(239, 151);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 21;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 102);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 19;
            label4.Text = "Comisión";
            // 
            // comisionComboBox
            // 
            comisionComboBox.FormattingEnabled = true;
            comisionComboBox.Location = new Point(106, 99);
            comisionComboBox.Name = "comisionComboBox";
            comisionComboBox.Size = new Size(146, 23);
            comisionComboBox.TabIndex = 18;
            // 
            // materiaComboBox
            // 
            materiaComboBox.FormattingEnabled = true;
            materiaComboBox.Location = new Point(106, 70);
            materiaComboBox.Name = "materiaComboBox";
            materiaComboBox.Size = new Size(146, 23);
            materiaComboBox.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 73);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 16;
            label3.Text = "Materia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 44);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 15;
            label2.Text = "Cupo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 14;
            label1.Text = "Año Calendario";
            // 
            // cupoBox
            // 
            cupoBox.Location = new Point(106, 41);
            cupoBox.Name = "cupoBox";
            cupoBox.Size = new Size(86, 23);
            cupoBox.TabIndex = 13;
            // 
            // anioCalendarioBox
            // 
            anioCalendarioBox.Location = new Point(106, 12);
            anioCalendarioBox.Name = "anioCalendarioBox";
            anioCalendarioBox.Size = new Size(86, 23);
            anioCalendarioBox.TabIndex = 12;
            // 
            // ModificarCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 190);
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
            Name = "ModificarCurso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Curso";
            Load += ModificarCurso_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button agregarCurso;
        private Button cancelarButton;
        private Label label4;
        private ComboBox comisionComboBox;
        private ComboBox materiaComboBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox cupoBox;
        private TextBox anioCalendarioBox;
    }
}