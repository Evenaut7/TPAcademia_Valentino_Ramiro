namespace VistaEscritorio
{
    partial class ModificarMateria
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
            agregarMateria = new Button();
            cancelarButton = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            horaHastaBox = new TextBox();
            horaDesdeBox = new TextBox();
            descBox = new TextBox();
            idMateria = new TextBox();
            label6 = new Label();
            idPlanBox = new ComboBox();
            SuspendLayout();
            // 
            // agregarMateria
            // 
            agregarMateria.Location = new Point(129, 253);
            agregarMateria.Name = "agregarMateria";
            agregarMateria.Size = new Size(75, 23);
            agregarMateria.TabIndex = 24;
            agregarMateria.Text = "Aceptar";
            agregarMateria.UseVisualStyleBackColor = true;
            agregarMateria.Click += agregarMateria_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(210, 253);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 23;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 166);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 22;
            label5.Text = "ID plan";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 137);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 21;
            label4.Text = "Hora Hasta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 108);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 20;
            label3.Text = "Hora Desde";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 79);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 19;
            label2.Text = "Descripcion";
            // 
            // horaHastaBox
            // 
            horaHastaBox.Location = new Point(92, 134);
            horaHastaBox.Name = "horaHastaBox";
            horaHastaBox.Size = new Size(193, 23);
            horaHastaBox.TabIndex = 16;
            // 
            // horaDesdeBox
            // 
            horaDesdeBox.Location = new Point(92, 105);
            horaDesdeBox.Name = "horaDesdeBox";
            horaDesdeBox.Size = new Size(193, 23);
            horaDesdeBox.TabIndex = 15;
            // 
            // descBox
            // 
            descBox.Location = new Point(92, 76);
            descBox.Name = "descBox";
            descBox.Size = new Size(193, 23);
            descBox.TabIndex = 14;
            // 
            // idMateria
            // 
            idMateria.Location = new Point(134, 12);
            idMateria.Name = "idMateria";
            idMateria.Size = new Size(151, 23);
            idMateria.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 15);
            label6.Name = "label6";
            label6.Size = new Size(110, 15);
            label6.TabIndex = 26;
            label6.Text = "Materia a Modificar";
            // 
            // idPlanBox
            // 
            idPlanBox.DropDownStyle = ComboBoxStyle.DropDownList;
            idPlanBox.FormattingEnabled = true;
            idPlanBox.Location = new Point(92, 163);
            idPlanBox.Name = "idPlanBox";
            idPlanBox.Size = new Size(121, 23);
            idPlanBox.TabIndex = 27;
            idPlanBox.SelectedIndexChanged += idPlanBox_SelectedIndexChanged;
            // 
            // ModificarMateria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 296);
            Controls.Add(idPlanBox);
            Controls.Add(label6);
            Controls.Add(idMateria);
            Controls.Add(agregarMateria);
            Controls.Add(cancelarButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(horaHastaBox);
            Controls.Add(horaDesdeBox);
            Controls.Add(descBox);
            Name = "ModificarMateria";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Materia";
            Load += ModificarMateria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button agregarMateria;
        private Button cancelarButton;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox horaHastaBox;
        private TextBox horaDesdeBox;
        private TextBox descBox;
        private TextBox idMateria;
        private Label label6;
        private ComboBox idPlanBox;

        // Add this method to handle the 'Click' event for the 'agregarMateria' button.
        private void agregarMateria_Click(object sender, EventArgs e)
        {
            // TODO: Add the logic for handling the button click event here.
            MessageBox.Show("Agregar Materia button clicked!");
        }

        // Add this method to handle the 'SelectedIndexChanged' event for the 'idPlanBox' ComboBox.
        private void idPlanBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Add logic to handle the event when the selected index changes.
            MessageBox.Show("Selected plan changed!");
        }
    }
}