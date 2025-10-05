namespace VistaEscritorio
{
    partial class CargarUsuario
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            nombreUsuarioBox = new TextBox();
            claveBox = new TextBox();
            emailBox = new TextBox();
            privilegioBox = new ComboBox();
            habilitadoCheck = new CheckBox();
            personaComboBox = new ComboBox();
            agregarButton = new Button();
            cancelarButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // Campos
            nombreUsuarioBox.Location = new Point(120, 20);
            claveBox.Location = new Point(120, 50);
            emailBox.Location = new Point(120, 80);
            privilegioBox.Items.AddRange(new object[] { "Usuario", "Administrador" });
            privilegioBox.Location = new Point(120, 110);
            habilitadoCheck.Location = new Point(120, 140);
            personaComboBox.Location = new Point(120, 170);
            // 
            // Botones
            agregarButton.Location = new Point(120, 210);
            agregarButton.Text = "Agregar";
            agregarButton.Click += agregarButton_Click;
            cancelarButton.Location = new Point(200, 210);
            cancelarButton.Text = "Cancelar";
            cancelarButton.Click += cancelarButton_Click;
            // 
            // Labels
            label1.Text = "Nombre Usuario"; label1.Location = new Point(10, 20);
            label2.Text = "Clave"; label2.Location = new Point(10, 50);
            label3.Text = "Email"; label3.Location = new Point(10, 80);
            label4.Text = "Privilegio"; label4.Location = new Point(10, 110);
            label5.Text = "Habilitado"; label5.Location = new Point(10, 140);
            label6.Text = "Persona"; label6.Location = new Point(10, 170);
            // 
            // Form
            ClientSize = new Size(300, 260);
            Controls.AddRange(new Control[] { nombreUsuarioBox, claveBox, emailBox, privilegioBox, habilitadoCheck, personaComboBox, agregarButton, cancelarButton, label1, label2, label3, label4, label5, label6 });
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar Usuario";
            Load += CargarUsuario_Load;
            ResumeLayout(false);
        }

        private TextBox nombreUsuarioBox, claveBox, emailBox;
        private ComboBox privilegioBox, personaComboBox;
        private CheckBox habilitadoCheck;
        private Button agregarButton, cancelarButton;
        private Label label1, label2, label3, label4, label5, label6;
    }
}
