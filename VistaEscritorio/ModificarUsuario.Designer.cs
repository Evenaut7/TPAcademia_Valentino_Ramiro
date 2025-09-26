namespace VistaEscritorio
{
    partial class ModificarUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label apellidoLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label alumnoLabel; // Cambiado
        private System.Windows.Forms.Label claveLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox apellidoTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox alumnoTextBox; // Cambiado
        private System.Windows.Forms.TextBox claveTextBox;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button cancelarButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            nombreLabel = new System.Windows.Forms.Label();
            apellidoLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            alumnoLabel = new System.Windows.Forms.Label(); // Cambiado
            claveLabel = new System.Windows.Forms.Label();
            nombreTextBox = new System.Windows.Forms.TextBox();
            apellidoTextBox = new System.Windows.Forms.TextBox();
            emailTextBox = new System.Windows.Forms.TextBox();
            alumnoTextBox = new System.Windows.Forms.TextBox(); // Cambiado
            claveTextBox = new System.Windows.Forms.TextBox();
            modificarButton = new System.Windows.Forms.Button();
            cancelarButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(30, 30);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(54, 15);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre:";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new System.Drawing.Point(120, 27);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new System.Drawing.Size(200, 23);
            nombreTextBox.TabIndex = 1;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new System.Drawing.Point(30, 65);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new System.Drawing.Size(54, 15);
            apellidoLabel.TabIndex = 2;
            apellidoLabel.Text = "Apellido:";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new System.Drawing.Point(120, 62);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new System.Drawing.Size(200, 23);
            apellidoTextBox.TabIndex = 3;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(30, 100);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(41, 15);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new System.Drawing.Point(120, 97);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new System.Drawing.Size(200, 23);
            emailTextBox.TabIndex = 5;
            // 
            // alumnoLabel
            // 
            alumnoLabel.AutoSize = true;
            alumnoLabel.Location = new System.Drawing.Point(30, 135);
            alumnoLabel.Name = "alumnoLabel";
            alumnoLabel.Size = new System.Drawing.Size(54, 15);
            alumnoLabel.TabIndex = 6;
            alumnoLabel.Text = "Alumno:"; // Cambiado
                                          // 
                                          // alumnoTextBox
                                          // 
            alumnoTextBox.Location = new System.Drawing.Point(120, 132);
            alumnoTextBox.Name = "alumnoTextBox";
            alumnoTextBox.Size = new System.Drawing.Size(200, 23);
            alumnoTextBox.TabIndex = 7;
            // 
            // claveLabel
            // 
            claveLabel.AutoSize = true;
            claveLabel.Location = new System.Drawing.Point(30, 170);
            claveLabel.Name = "claveLabel";
            claveLabel.Size = new System.Drawing.Size(40, 15);
            claveLabel.TabIndex = 8;
            claveLabel.Text = "Clave:";
            // 
            // claveTextBox
            // 
            claveTextBox.Location = new System.Drawing.Point(120, 167);
            claveTextBox.Name = "claveTextBox";
            claveTextBox.Size = new System.Drawing.Size(200, 23);
            claveTextBox.TabIndex = 9;
            claveTextBox.UseSystemPasswordChar = true;
            // 
            // modificarButton
            // 
            modificarButton.Location = new System.Drawing.Point(120, 210);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new System.Drawing.Size(90, 27);
            modificarButton.TabIndex = 10;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new System.Drawing.Point(230, 210);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new System.Drawing.Size(90, 27);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // ModificarUsuario
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(370, 260);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(alumnoLabel); // Cambiado
            Controls.Add(alumnoTextBox); // Cambiado
            Controls.Add(claveLabel);
            Controls.Add(claveTextBox);
            Controls.Add(modificarButton);
            Controls.Add(cancelarButton);
            Name = "ModificarUsuario";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Modificar Alumno"; // Cambiado
            ResumeLayout(false);
            PerformLayout();
        }
    }
}