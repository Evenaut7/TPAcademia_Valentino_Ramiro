namespace VistaEscritorio
{
    partial class CargaEspecialidades
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
            descText = new TextBox();
            descLabel = new Label();
            agregarEspecialidad = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // descText
            // 
            descText.Location = new Point(87, 28);
            descText.Name = "descText";
            descText.Size = new Size(198, 23);
            descText.TabIndex = 0;
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new Point(12, 31);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(69, 15);
            descLabel.TabIndex = 1;
            descLabel.Text = "Descripcion";
            // 
            // agregarEspecialidad
            // 
            agregarEspecialidad.Location = new Point(157, 80);
            agregarEspecialidad.Name = "agregarEspecialidad";
            agregarEspecialidad.Size = new Size(75, 23);
            agregarEspecialidad.TabIndex = 4;
            agregarEspecialidad.Text = "Agregar";
            agregarEspecialidad.UseVisualStyleBackColor = true;
            agregarEspecialidad.Click += agregarEspecialidad_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(238, 80);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 5;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // CargaEspecialidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 115);
            Controls.Add(agregarEspecialidad);
            Controls.Add(cancelarButton);
            Controls.Add(descLabel);
            Controls.Add(descText);
            Name = "CargaEspecialidades";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Especialidad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox descText;
        private Label descLabel;
        private Button agregarEspecialidad;
        private Button cancelarButton;
    }
}