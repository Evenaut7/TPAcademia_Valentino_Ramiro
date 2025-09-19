namespace VistaEscritorio
{
    partial class CargaMaterias
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
            descBox = new TextBox();
            horaHastaBox = new TextBox();
            horaDesdeBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cancelarButton = new Button();
            agregarMateria = new Button();
            idPlanBox = new ComboBox();
            SuspendLayout();
            // 
            // descBox
            // 
            descBox.Location = new Point(85, 17);
            descBox.Name = "descBox";
            descBox.Size = new Size(193, 23);
            descBox.TabIndex = 1;
            // 
            // horaHastaBox
            // 
            horaHastaBox.Location = new Point(85, 75);
            horaHastaBox.Name = "horaHastaBox";
            horaHastaBox.Size = new Size(193, 23);
            horaHastaBox.TabIndex = 3;
            // 
            // horaDesdeBox
            // 
            horaDesdeBox.Location = new Point(85, 46);
            horaDesdeBox.Name = "horaDesdeBox";
            horaDesdeBox.Size = new Size(193, 23);
            horaDesdeBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 20);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 7;
            label2.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 49);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 8;
            label3.Text = "Hora Desde";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 78);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 9;
            label4.Text = "Hora Hasta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 107);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 10;
            label5.Text = "Plan";
            label5.Click += label5_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(275, 181);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // agregarMateria
            // 
            agregarMateria.Location = new Point(194, 181);
            agregarMateria.Name = "agregarMateria";
            agregarMateria.Size = new Size(75, 23);
            agregarMateria.TabIndex = 12;
            agregarMateria.Text = "Aceptar";
            agregarMateria.UseVisualStyleBackColor = true;
            agregarMateria.Click += agregarMateria_Click;
            // 
            // idPlanBox
            // 
            idPlanBox.DropDownStyle = ComboBoxStyle.DropDownList;
            idPlanBox.FormattingEnabled = true;
            idPlanBox.Location = new Point(85, 104);
            idPlanBox.Name = "idPlanBox";
            idPlanBox.Size = new Size(121, 23);
            idPlanBox.TabIndex = 13;
            // 
            // CargaMaterias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 229);
            Controls.Add(agregarMateria);
            Controls.Add(cancelarButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(idPlanBox);
            Controls.Add(horaHastaBox);
            Controls.Add(horaDesdeBox);
            Controls.Add(descBox);
            Name = "CargaMaterias";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ingrese una materia";
            Load += CargaMaterias_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox descBox;
        private TextBox horaHastaBox;
        private TextBox horaDesdeBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button cancelarButton;
        private Button agregarMateria;
        private ComboBox idPlanBox;
    }
}