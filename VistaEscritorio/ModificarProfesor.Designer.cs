namespace VistaEscritorio
{
    partial class ModificarProfesor
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
            nombreBox = new TextBox();
            apellidoBox = new TextBox();
            dniBox = new TextBox();
            cargoBox = new TextBox();
            fechaNacimientoPicker = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            modificarProfesorButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // nombreBox
            // 
            nombreBox.Location = new Point(160, 20);
            nombreBox.Name = "nombreBox";
            nombreBox.Size = new Size(150, 23);
            nombreBox.TabIndex = 0;
            // 
            // apellidoBox
            // 
            apellidoBox.Location = new Point(160, 49);
            apellidoBox.Name = "apellidoBox";
            apellidoBox.Size = new Size(150, 23);
            apellidoBox.TabIndex = 1;
            // 
            // dniBox
            // 
            dniBox.Location = new Point(160, 78);
            dniBox.Name = "dniBox";
            dniBox.Size = new Size(150, 23);
            dniBox.TabIndex = 2;
            // 
            // cargoBox
            // 
            cargoBox.Location = new Point(160, 136);
            cargoBox.Name = "cargoBox";
            cargoBox.Size = new Size(150, 23);
            cargoBox.TabIndex = 4;
            // 
            // fechaNacimientoPicker
            // 
            fechaNacimientoPicker.Format = DateTimePickerFormat.Short;
            fechaNacimientoPicker.Location = new Point(160, 107);
            fechaNacimientoPicker.Name = "fechaNacimientoPicker";
            fechaNacimientoPicker.Size = new Size(150, 23);
            fechaNacimientoPicker.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 23);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 5;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 52);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 6;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 81);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 7;
            label3.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 110);
            label4.Name = "label4";
            label4.Size = new Size(119, 15);
            label4.TabIndex = 8;
            label4.Text = "Fecha de Nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 139);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "Cargo";
            // 
            // modificarProfesorButton
            // 
            modificarProfesorButton.Location = new Point(154, 185);
            modificarProfesorButton.Name = "modificarProfesorButton";
            modificarProfesorButton.Size = new Size(75, 23);
            modificarProfesorButton.TabIndex = 5;
            modificarProfesorButton.Text = "Modificar";
            modificarProfesorButton.UseVisualStyleBackColor = true;
            modificarProfesorButton.Click += modificarProfesorButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(235, 185);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 6;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // ModificarProfesor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 230);
            Controls.Add(cancelarButton);
            Controls.Add(modificarProfesorButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fechaNacimientoPicker);
            Controls.Add(cargoBox);
            Controls.Add(dniBox);
            Controls.Add(apellidoBox);
            Controls.Add(nombreBox);
            Name = "ModificarProfesor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Profesor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nombreBox;
        private TextBox apellidoBox;
        private TextBox dniBox;
        private TextBox cargoBox;
        private DateTimePicker fechaNacimientoPicker;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button modificarProfesorButton;
        private Button cancelarButton;
    }
}