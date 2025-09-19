namespace VistaEscritorio
{
    partial class ModificarEspecialidad
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
            aceptarButton = new Button();
            cancelarButton = new Button();
            descLabel = new Label();
            descText = new TextBox();
            SuspendLayout();
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(201, 71);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(75, 23);
            aceptarButton.TabIndex = 8;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click_1;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(282, 71);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 9;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new Point(12, 21);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(106, 15);
            descLabel.TabIndex = 7;
            descLabel.Text = "Nueva Descripcion";
            // 
            // descText
            // 
            descText.Location = new Point(124, 18);
            descText.Name = "descText";
            descText.Size = new Size(233, 23);
            descText.TabIndex = 6;
            descText.TextChanged += descText_TextChanged;
            // 
            // ModificarEspecialidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 108);
            Controls.Add(aceptarButton);
            Controls.Add(cancelarButton);
            Controls.Add(descLabel);
            Controls.Add(descText);
            Name = "ModificarEspecialidad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Especialidad";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button aceptarButton;
        private Button cancelarButton;
        private Label descLabel;
        private TextBox descText;
    }
}