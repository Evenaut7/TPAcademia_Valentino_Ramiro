namespace VistaEscritorio
{
    partial class UsuarioRegistrar
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
            NombreLabel = new Label();
            ApellidoLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoTextBox = new TextBox();
            emailTextBox = new TextBox();
            EmailLabel = new Label();
            label4 = new Label();
            label5 = new Label();
            usuarioTextBox = new TextBox();
            claveTextBox = new TextBox();
            registrarseButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // NombreLabel
            // 
            NombreLabel.AutoSize = true;
            NombreLabel.Location = new Point(313, 107);
            NombreLabel.Name = "NombreLabel";
            NombreLabel.Size = new Size(51, 15);
            NombreLabel.TabIndex = 0;
            NombreLabel.Text = "Nombre";
            NombreLabel.Click += label1_Click;
            // 
            // ApellidoLabel
            // 
            ApellidoLabel.AutoSize = true;
            ApellidoLabel.Location = new Point(313, 170);
            ApellidoLabel.Name = "ApellidoLabel";
            ApellidoLabel.Size = new Size(51, 15);
            ApellidoLabel.TabIndex = 1;
            ApellidoLabel.Text = "Apellido";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(313, 125);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(173, 23);
            nombreTextBox.TabIndex = 2;
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(313, 188);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(173, 23);
            apellidoTextBox.TabIndex = 3;
            apellidoTextBox.TextChanged += textBox1_TextChanged;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(313, 243);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(173, 23);
            emailTextBox.TabIndex = 4;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(313, 225);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(36, 15);
            EmailLabel.TabIndex = 5;
            EmailLabel.Text = "Email";
            EmailLabel.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(313, 288);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 6;
            label4.Text = "Nombre de Usuario";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(313, 340);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 7;
            label5.Text = "Clave";
            label5.Click += label5_Click;
            // 
            // usuarioTextBox
            // 
            usuarioTextBox.Location = new Point(313, 306);
            usuarioTextBox.Name = "usuarioTextBox";
            usuarioTextBox.Size = new Size(173, 23);
            usuarioTextBox.TabIndex = 8;
            // 
            // claveTextBox
            // 
            claveTextBox.Location = new Point(313, 358);
            claveTextBox.Name = "claveTextBox";
            claveTextBox.Size = new Size(173, 23);
            claveTextBox.TabIndex = 9;
            claveTextBox.TextChanged += textBox2_TextChanged;
            // 
            // registrarseButton
            // 
            registrarseButton.Location = new Point(313, 409);
            registrarseButton.Name = "registrarseButton";
            registrarseButton.Size = new Size(173, 32);
            registrarseButton.TabIndex = 10;
            registrarseButton.Text = "Registrarse";
            registrarseButton.UseVisualStyleBackColor = true;
            registrarseButton.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F);
            label1.Location = new Point(279, 9);
            label1.Name = "label1";
            label1.Size = new Size(241, 51);
            label1.TabIndex = 11;
            label1.Text = "Crear Cuenta";
            label1.Click += label1_Click_1;
            // 
            // UsuarioRegistrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 492);
            Controls.Add(label1);
            Controls.Add(registrarseButton);
            Controls.Add(claveTextBox);
            Controls.Add(usuarioTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(EmailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(apellidoTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(ApellidoLabel);
            Controls.Add(NombreLabel);
            Name = "UsuarioRegistrar";
            Text = "Form1";
            Load += UsuarioRegistrar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NombreLabel;
        private Label ApellidoLabel;
        private TextBox nombreTextBox;
        private TextBox apellidoTextBox;
        private TextBox emailTextBox;
        private Label EmailLabel;
        private Label label4;
        private Label label5;
        private TextBox usuarioTextBox;
        private TextBox claveTextBox;
        private Button registrarseButton;
        private Label label1;
    }
}