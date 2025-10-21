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
            // nombreUsuarioBox
            // 
            nombreUsuarioBox.Location = new Point(120, 20);
            nombreUsuarioBox.Name = "nombreUsuarioBox";
            nombreUsuarioBox.Size = new Size(100, 23);
            nombreUsuarioBox.TabIndex = 0;
            // 
            // claveBox
            // 
            claveBox.Location = new Point(120, 50);
            claveBox.Name = "claveBox";
            claveBox.Size = new Size(100, 23);
            claveBox.TabIndex = 1;
            // 
            // emailBox
            // 
            emailBox.Location = new Point(120, 80);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(100, 23);
            emailBox.TabIndex = 2;
            // 
            // privilegioBox
            // 
            privilegioBox.Items.AddRange(new object[] { "Usuario", "Administrador" });
            privilegioBox.Location = new Point(120, 110);
            privilegioBox.Name = "privilegioBox";
            privilegioBox.Size = new Size(121, 23);
            privilegioBox.TabIndex = 3;
            // 
            // habilitadoCheck
            // 
            habilitadoCheck.Location = new Point(120, 140);
            habilitadoCheck.Name = "habilitadoCheck";
            habilitadoCheck.Size = new Size(104, 24);
            habilitadoCheck.TabIndex = 4;
            // 
            // personaComboBox
            // 
            personaComboBox.Location = new Point(120, 170);
            personaComboBox.Name = "personaComboBox";
            personaComboBox.Size = new Size(121, 23);
            personaComboBox.TabIndex = 5;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(120, 210);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(75, 23);
            agregarButton.TabIndex = 6;
            agregarButton.Text = "Agregar";
            agregarButton.Click += agregarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(200, 210);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 7;
            cancelarButton.Text = "Cancelar";
            cancelarButton.Click += cancelarButton_Click;
            // 
            // label1
            // 
            label1.Location = new Point(10, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 8;
            label1.Text = "Nombre Usuario";
            // 
            // label2
            // 
            label2.Location = new Point(10, 50);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 9;
            label2.Text = "Clave";
            // 
            // label3
            // 
            label3.Location = new Point(10, 80);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 10;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.Location = new Point(10, 110);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 11;
            label4.Text = "Privilegio";
            // 
            // label5
            // 
            label5.Location = new Point(10, 140);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 12;
            label5.Text = "Habilitado";
            // 
            // label6
            // 
            label6.Location = new Point(10, 170);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 13;
            label6.Text = "Alumno";
            label6.Click += label6_Click;
            // 
            // CargarUsuario
            // 
            ClientSize = new Size(300, 260);
            Controls.Add(nombreUsuarioBox);
            Controls.Add(claveBox);
            Controls.Add(emailBox);
            Controls.Add(privilegioBox);
            Controls.Add(habilitadoCheck);
            Controls.Add(personaComboBox);
            Controls.Add(agregarButton);
            Controls.Add(cancelarButton);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Name = "CargarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar Usuario";
            Load += CargarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox nombreUsuarioBox, claveBox, emailBox;
        private ComboBox privilegioBox, personaComboBox;
        private CheckBox habilitadoCheck;
        private Button agregarButton, cancelarButton;
        private Label label1, label2, label3, label4, label5, label6;
    }
}
