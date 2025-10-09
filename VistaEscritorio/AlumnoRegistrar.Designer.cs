namespace VistaEscritorio
{
    partial class AlumnoRegistrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label apellidoLabel;
        private System.Windows.Forms.TextBox apellidoTextBox;
        private System.Windows.Forms.Label dniLabel;
        private System.Windows.Forms.TextBox dniTextBox;
        private System.Windows.Forms.Label fechaNacimientoLabel;
        private System.Windows.Forms.DateTimePicker fechaNacimientoPicker;
        private System.Windows.Forms.Label legajoLabel;
        private System.Windows.Forms.TextBox legajoTextBox;
        private System.Windows.Forms.Button registrarButton;

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
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoLabel = new Label();
            apellidoTextBox = new TextBox();
            dniLabel = new Label();
            dniTextBox = new TextBox();
            fechaNacimientoLabel = new Label();
            fechaNacimientoPicker = new DateTimePicker();
            legajoLabel = new Label();
            legajoTextBox = new TextBox();
            registrarButton = new Button();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.Location = new Point(228, 56);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(100, 19);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre:";
            nombreLabel.Click += nombreLabel_Click;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(228, 78);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(200, 23);
            nombreTextBox.TabIndex = 1;
            // 
            // apellidoLabel
            // 
            apellidoLabel.Location = new Point(228, 127);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(100, 18);
            apellidoLabel.TabIndex = 2;
            apellidoLabel.Text = "Apellido:";
            apellidoLabel.Click += apellidoLabel_Click;
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(228, 148);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(200, 23);
            apellidoTextBox.TabIndex = 3;
            // 
            // dniLabel
            // 
            dniLabel.Location = new Point(228, 186);
            dniLabel.Name = "dniLabel";
            dniLabel.Size = new Size(100, 20);
            dniLabel.TabIndex = 4;
            dniLabel.Text = "DNI:";
            // 
            // dniTextBox
            // 
            dniTextBox.Location = new Point(228, 209);
            dniTextBox.Name = "dniTextBox";
            dniTextBox.Size = new Size(200, 23);
            dniTextBox.TabIndex = 5;
            // 
            // fechaNacimientoLabel
            // 
            fechaNacimientoLabel.Location = new Point(228, 251);
            fechaNacimientoLabel.Name = "fechaNacimientoLabel";
            fechaNacimientoLabel.Size = new Size(127, 27);
            fechaNacimientoLabel.TabIndex = 6;
            fechaNacimientoLabel.Text = "Fecha de Nacimiento:";
            fechaNacimientoLabel.Click += fechaNacimientoLabel_Click;
            // 
            // fechaNacimientoPicker
            // 
            fechaNacimientoPicker.Location = new Point(228, 281);
            fechaNacimientoPicker.Name = "fechaNacimientoPicker";
            fechaNacimientoPicker.Size = new Size(200, 23);
            fechaNacimientoPicker.TabIndex = 7;
            // 
            // legajoLabel
            // 
            legajoLabel.Location = new Point(228, 330);
            legajoLabel.Name = "legajoLabel";
            legajoLabel.Size = new Size(100, 18);
            legajoLabel.TabIndex = 8;
            legajoLabel.Text = "Legajo:";
            legajoLabel.Click += legajoLabel_Click;
            // 
            // legajoTextBox
            // 
            legajoTextBox.Location = new Point(228, 351);
            legajoTextBox.Name = "legajoTextBox";
            legajoTextBox.Size = new Size(200, 23);
            legajoTextBox.TabIndex = 9;
            // 
            // registrarButton
            // 
            registrarButton.Location = new Point(228, 389);
            registrarButton.Name = "registrarButton";
            registrarButton.Size = new Size(200, 23);
            registrarButton.TabIndex = 18;
            registrarButton.Text = "Registrar";
            registrarButton.Click += registrarButton_Click;
            // 
            // AlumnoRegistrar
            // 
            ClientSize = new Size(697, 528);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(dniLabel);
            Controls.Add(dniTextBox);
            Controls.Add(fechaNacimientoLabel);
            Controls.Add(fechaNacimientoPicker);
            Controls.Add(legajoLabel);
            Controls.Add(legajoTextBox);
            Controls.Add(registrarButton);
            Name = "AlumnoRegistrar";
            Text = "Registrar Alumno";
            Load += AlumnoRegistrar_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        private void AlumnoRegistrar_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}