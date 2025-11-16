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
            planComboBox = new ComboBox();
            modificarButton = new Button();
            cancelarButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lblEstado = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            lblTitulo = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // nombreUsuarioBox
            // 
            nombreUsuarioBox.Location = new Point(150, 60);
            nombreUsuarioBox.Name = "nombreUsuarioBox";
            nombreUsuarioBox.Size = new Size(200, 27);
            nombreUsuarioBox.TabIndex = 0;
            // 
            // claveBox
            // 
            claveBox.Location = new Point(150, 90);
            claveBox.Name = "claveBox";
            claveBox.Size = new Size(200, 27);
            claveBox.TabIndex = 1;
            claveBox.UseSystemPasswordChar = true;
            // 
            // emailBox
            // 
            emailBox.Location = new Point(150, 120);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(200, 27);
            emailBox.TabIndex = 2;
            // 
            // tipoBox
            // 
            tipoBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoBox.Items.AddRange(new object[] { "Administrador", "Profesor", "Alumno" });
            tipoBox.Location = new Point(150, 150);
            tipoBox.Name = "tipoBox";
            tipoBox.Size = new Size(200, 28);
            tipoBox.TabIndex = 3;
            tipoBox.SelectedIndexChanged += tipoBox_SelectedIndexChanged;
            // 
            // legajoBox
            // 
            legajoBox.Location = new Point(150, 180);
            legajoBox.Name = "legajoBox";
            legajoBox.Size = new Size(200, 27);
            legajoBox.TabIndex = 4;
            // 
            // habilitadoCheck
            // 
            habilitadoCheck.AutoSize = true;
            habilitadoCheck.Location = new Point(150, 210);
            habilitadoCheck.Name = "habilitadoCheck";
            habilitadoCheck.Size = new Size(18, 17);
            habilitadoCheck.TabIndex = 5;
            habilitadoCheck.UseVisualStyleBackColor = true;
            // 
            // personaComboBox
            // 
            personaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            personaComboBox.Location = new Point(150, 235);
            personaComboBox.Name = "personaComboBox";
            personaComboBox.Size = new Size(200, 28);
            personaComboBox.TabIndex = 6;
            // 
            // planComboBox
            // 
            planComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            planComboBox.Location = new Point(150, 265);
            planComboBox.Name = "planComboBox";
            planComboBox.Size = new Size(200, 28);
            planComboBox.TabIndex = 7;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(194, 10);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(75, 30);
            modificarButton.TabIndex = 8;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(275, 10);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(75, 30);
            cancelarButton.TabIndex = 9;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 63);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 10;
            label1.Text = "Nombre Usuario: *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 93);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 11;
            label2.Text = "Clave:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 123);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 12;
            label3.Text = "Email: *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 153);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 13;
            label4.Text = "Tipo: *";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 183);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 14;
            label5.Text = "Legajo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 210);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 15;
            label6.Text = "Habilitado:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 238);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 16;
            label7.Text = "Persona: *";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 268);
            label8.Name = "label8";
            label8.Size = new Size(40, 20);
            label8.TabIndex = 17;
            label8.Text = "Plan:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(10, 17);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 20);
            lblEstado.TabIndex = 18;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblEstado);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(cancelarButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 363);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(380, 50);
            panel1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTitulo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(380, 54);
            panel2.TabIndex = 20;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Modificar Usuario";
            // 
            // ModificarUsuario
            // 
            ClientSize = new Size(380, 413);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(planComboBox);
            Controls.Add(personaComboBox);
            Controls.Add(habilitadoCheck);
            Controls.Add(legajoBox);
            Controls.Add(tipoBox);
            Controls.Add(emailBox);
            Controls.Add(claveBox);
            Controls.Add(nombreUsuarioBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ModificarUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Usuario";
            Load += ModificarUsuario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox nombreUsuarioBox, claveBox, emailBox, legajoBox;
        private ComboBox tipoBox, personaComboBox, planComboBox;
        private CheckBox habilitadoCheck;
        private Button modificarButton, cancelarButton;
        private Label label1, label2, label3, label4, label5, label6, label7, label8;
        private Label lblEstado;
        private Panel panel1;
        private Panel panel2;
        private Label lblTitulo;
    }
}