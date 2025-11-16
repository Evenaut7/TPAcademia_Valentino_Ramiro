namespace VistaEscritorio
{
    partial class PersonaRegistrar
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label apellidoLabel;
        private System.Windows.Forms.TextBox apellidoTextBox;
        private System.Windows.Forms.Label dniLabel;
        private System.Windows.Forms.TextBox dniTextBox;
        private System.Windows.Forms.Label fechaNacimientoLabel;
        private System.Windows.Forms.DateTimePicker fechaNacimientoPicker;
        private System.Windows.Forms.Button registrarButton;

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
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoLabel = new Label();
            apellidoTextBox = new TextBox();
            dniLabel = new Label();
            dniTextBox = new TextBox();
            fechaNacimientoLabel = new Label();
            fechaNacimientoPicker = new DateTimePicker();
            registrarButton = new Button();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.Location = new Point(83, 57);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(57, 23);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre:";
            nombreLabel.Click += nombreLabel_Click;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(146, 54);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(190, 27);
            nombreTextBox.TabIndex = 1;
            // 
            // apellidoLabel
            // 
            apellidoLabel.Location = new Point(83, 97);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(54, 23);
            apellidoLabel.TabIndex = 2;
            apellidoLabel.Text = "Apellido:";
            apellidoLabel.Click += apellidoLabel_Click;
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(146, 94);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(190, 27);
            apellidoTextBox.TabIndex = 3;
            // 
            // dniLabel
            // 
            dniLabel.Location = new Point(91, 137);
            dniLabel.Name = "dniLabel";
            dniLabel.Size = new Size(46, 23);
            dniLabel.TabIndex = 4;
            dniLabel.Text = "DNI:";
            // 
            // dniTextBox
            // 
            dniTextBox.Location = new Point(146, 134);
            dniTextBox.Name = "dniTextBox";
            dniTextBox.Size = new Size(190, 27);
            dniTextBox.TabIndex = 5;
            // 
            // fechaNacimientoLabel
            // 
            fechaNacimientoLabel.Location = new Point(65, 174);
            fechaNacimientoLabel.Name = "fechaNacimientoLabel";
            fechaNacimientoLabel.Size = new Size(75, 32);
            fechaNacimientoLabel.TabIndex = 6;
            fechaNacimientoLabel.Text = "Fecha de Nacimiento:";
            fechaNacimientoLabel.Click += fechaNacimientoLabel_Click;
            // 
            // fechaNacimientoPicker
            // 
            fechaNacimientoPicker.Location = new Point(146, 183);
            fechaNacimientoPicker.Name = "fechaNacimientoPicker";
            fechaNacimientoPicker.Size = new Size(190, 27);
            fechaNacimientoPicker.TabIndex = 7;
            // 
            // registrarButton
            // 
            registrarButton.Location = new Point(123, 240);
            registrarButton.Name = "registrarButton";
            registrarButton.Size = new Size(133, 23);
            registrarButton.TabIndex = 8;
            registrarButton.Text = "Cargar";
            registrarButton.Click += registrarButton_Click;
            // 
            // PersonaRegistrar
            // 
            ClientSize = new Size(400, 320);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(dniLabel);
            Controls.Add(dniTextBox);
            Controls.Add(fechaNacimientoLabel);
            Controls.Add(fechaNacimientoPicker);
            Controls.Add(registrarButton);
            Name = "PersonaRegistrar";
            Text = "Registrar Persona";
            Load += PersonaRegistrar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

    }
}