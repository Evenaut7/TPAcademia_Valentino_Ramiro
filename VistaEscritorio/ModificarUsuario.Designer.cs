namespace VistaEscritorio
{
    partial class ModificarUsuario
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
            tipoBox = new ComboBox();
            legajoBox = new TextBox();
            habilitadoCheck = new CheckBox();
            personaComboBox = new ComboBox();
            modificarButton = new Button();
            cancelarButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // nombreUsuarioBox
            // 
            nombreUsuarioBox.Location = new Point(140, 20);
            nombreUsuarioBox.Name = "nombreUsuarioBox";
            nombreUsuarioBox.Size = new Size(150, 23);
            nombreUsuarioBox.TabIndex = 0;
            // 
            // claveBox
            // 
            claveBox.Location = new Point(140, 50);
            claveBox.Name = "claveBox";
            claveBox.Size = new Size(150, 23);
            claveBox.TabIndex = 1;
            claveBox.PasswordChar = '*';
            // 
            // emailBox
            // 
            emailBox.Location = new Point(140, 80);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(150, 23);
            emailBox.TabIndex = 2;
            // 
            // tipoBox
            // 
            tipoBox.Items.AddRange(new object[] { "Administrador", "Profesor", "Alumno" });
            tipoBox.Location = new Point(140, 110);
            tipoBox.Name = "tipoBox";
            tipoBox.Size = new Size(150, 23);
            tipoBox.TabIndex = 3;
            // 
            // legajoBox
            // 
            legajoBox.Location = new Point(140, 140);
            legajoBox.Name = "legajoBox";
            legajoBox.Size = new Size(150, 23);
            legajoBox.TabIndex = 4;
            // 
            // habilitadoCheck
            // 
            habilitadoCheck.Location = new Point(140, 170);
            habilitadoCheck.Name = "habilitadoCheck";
            habilitadoCheck.Size = new Size(104, 24);
            habilitadoCheck.TabIndex = 5;
            // 
            // personaComboBox
            // 
            personaComboBox.Location = new Point(140, 200);
            personaComboBox.Name = "personaComboBox";
            personaComboBox.Size = new Size(150, 23);
            personaComboBox.TabIndex = 6;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(140, 240);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(75, 23);
            modificarButton.TabIndex = 7;
            modificarButton.Text = "Modificar";
            modificarButton.Click += modificarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(215, 240);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 23);
            cancelarButton.TabIndex = 8;
            cancelarButton.Text = "Cancelar";
            cancelarButton.Click += cancelarButton_Click;
            // 
            // label1
            // 
            label1.Location = new Point(10, 20);
            label1.Name = "label1";
            label1.Size = new Size(125, 23);
            label1.TabIndex = 9;
            label1.Text = "Nombre Usuario:";
            // 
            // label2
            // 
            label2.Location = new Point(10, 50);
            label2.Name = "label2";
            label2.Size = new Size(125, 23);
            label2.TabIndex = 10;
            label2.Text = "Clave:";
            // 
            // label3
            // 
            label3.Location = new Point(10, 80);
            label3.Name = "label3";
            label3.Size = new Size(125, 23);
            label3.TabIndex = 11;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.Location = new Point(10, 110);
            label4.Name = "label4";
            label4.Size = new Size(125, 23);
            label4.TabIndex = 12;
            label4.Text = "Tipo:";
            // 
            // label5
            // 
            label5.Location = new Point(10, 140);
            label5.Name = "label5";
            label5.Size = new Size(125, 23);
            label5.TabIndex = 13;
            label5.Text = "Legajo:";
            // 
            // label6
            // 
            label6.Location = new Point(10, 170);
            label6.Name = "label6";
            label6.Size = new Size(125, 23);
            label6.TabIndex = 14;
            label6.Text = "Habilitado:";
            // 
            // label7
            // 
            label7.Location = new Point(10, 200);
            label7.Name = "label7";
            label7.Size = new Size(125, 23);
            label7.TabIndex = 15;
            label7.Text = "Persona:";
            // 
            // ModificarUsuario
            // 
            ClientSize = new Size(320, 290);
            Controls.Add(nombreUsuarioBox);
            Controls.Add(claveBox);
            Controls.Add(emailBox);
            Controls.Add(tipoBox);
            Controls.Add(legajoBox);
            Controls.Add(habilitadoCheck);
            Controls.Add(personaComboBox);
            Controls.Add(modificarButton);
            Controls.Add(cancelarButton);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Name = "ModificarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Usuario";
            Load += ModificarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox nombreUsuarioBox, claveBox, emailBox, legajoBox;
        private ComboBox tipoBox, personaComboBox;
        private CheckBox habilitadoCheck;
        private Button modificarButton, cancelarButton;
        private Label label1, label2, label3, label4, label5, label6, label7;
    }
}