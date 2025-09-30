namespace VistaEscritorio
{
    partial class ModificarAlumno
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
        private System.Windows.Forms.Label legajoLabel;
        private System.Windows.Forms.TextBox legajoTextBox;

        private System.Windows.Forms.Label usuarioLabel;
        private System.Windows.Forms.TextBox usuarioTextBox;
        private System.Windows.Forms.Label claveLabel;
        private System.Windows.Forms.TextBox claveTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label privilegioLabel;
        private System.Windows.Forms.ComboBox privilegioComboBox;
        private System.Windows.Forms.Button guardarButton;

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
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.apellidoLabel = new System.Windows.Forms.Label();
            this.apellidoTextBox = new System.Windows.Forms.TextBox();
            this.dniLabel = new System.Windows.Forms.Label();
            this.dniTextBox = new System.Windows.Forms.TextBox();
            this.fechaNacimientoLabel = new System.Windows.Forms.Label();
            this.fechaNacimientoPicker = new System.Windows.Forms.DateTimePicker();
            this.legajoLabel = new System.Windows.Forms.Label();
            this.legajoTextBox = new System.Windows.Forms.TextBox();

            this.usuarioLabel = new System.Windows.Forms.Label();
            this.usuarioTextBox = new System.Windows.Forms.TextBox();
            this.claveLabel = new System.Windows.Forms.Label();
            this.claveTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.privilegioLabel = new System.Windows.Forms.Label();
            this.privilegioComboBox = new System.Windows.Forms.ComboBox();
            this.guardarButton = new System.Windows.Forms.Button();

            // Alumno fields
            this.nombreLabel.Text = "Nombre:";
            this.nombreLabel.Location = new System.Drawing.Point(20, 20);
            this.nombreTextBox.Location = new System.Drawing.Point(150, 20);

            this.apellidoLabel.Text = "Apellido:";
            this.apellidoLabel.Location = new System.Drawing.Point(20, 60);
            this.apellidoTextBox.Location = new System.Drawing.Point(150, 60);

            this.dniLabel.Text = "DNI:";
            this.dniLabel.Location = new System.Drawing.Point(20, 100);
            this.dniTextBox.Location = new System.Drawing.Point(150, 100);

            this.fechaNacimientoLabel.Text = "Fecha de Nacimiento:";
            this.fechaNacimientoLabel.Location = new System.Drawing.Point(20, 140);
            this.fechaNacimientoPicker.Location = new System.Drawing.Point(150, 140);

            this.legajoLabel.Text = "Legajo:";
            this.legajoLabel.Location = new System.Drawing.Point(20, 180);
            this.legajoTextBox.Location = new System.Drawing.Point(150, 180);

            // Usuario fields
            this.usuarioLabel.Text = "Nombre de Usuario:";
            this.usuarioLabel.Location = new System.Drawing.Point(20, 220);
            this.usuarioTextBox.Location = new System.Drawing.Point(150, 220);

            this.claveLabel.Text = "Clave:";
            this.claveLabel.Location = new System.Drawing.Point(20, 260);
            this.claveTextBox.Location = new System.Drawing.Point(150, 260);
            this.claveTextBox.PasswordChar = '*';

            this.emailLabel.Text = "Email:";
            this.emailLabel.Location = new System.Drawing.Point(20, 300);
            this.emailTextBox.Location = new System.Drawing.Point(150, 300);

            this.privilegioLabel.Text = "Privilegio:";
            this.privilegioLabel.Location = new System.Drawing.Point(20, 340);
            this.privilegioComboBox.Location = new System.Drawing.Point(150, 340);
            this.privilegioComboBox.Items.AddRange(new object[] { "Alumno", "Admin", "Profesor" });

            // Guardar Button
            this.guardarButton.Text = "Guardar";
            this.guardarButton.Location = new System.Drawing.Point(150, 380);
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);

            // Add controls
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.apellidoLabel);
            this.Controls.Add(this.apellidoTextBox);
            this.Controls.Add(this.dniLabel);
            this.Controls.Add(this.dniTextBox);
            this.Controls.Add(this.fechaNacimientoLabel);
            this.Controls.Add(this.fechaNacimientoPicker);
            this.Controls.Add(this.legajoLabel);
            this.Controls.Add(this.legajoTextBox);

            this.Controls.Add(this.usuarioLabel);
            this.Controls.Add(this.usuarioTextBox);
            this.Controls.Add(this.claveLabel);
            this.Controls.Add(this.claveTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.privilegioLabel);
            this.Controls.Add(this.privilegioComboBox);

            this.Controls.Add(this.guardarButton);

            // Form settings
            this.ClientSize = new System.Drawing.Size(400, 430);
            this.Text = "Modificar Alumno";
        }
    }
}