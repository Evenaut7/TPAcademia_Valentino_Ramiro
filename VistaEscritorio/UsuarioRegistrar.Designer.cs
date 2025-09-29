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
            // emailTextBox
            // 
            emailTextBox.Location = new Point(365, 146);
            emailTextBox.Margin = new Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(197, 27);
            emailTextBox.TabIndex = 4;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(365, 122);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(46, 20);
            EmailLabel.TabIndex = 5;
            EmailLabel.Text = "Email";
            EmailLabel.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(365, 206);
            label4.Name = "label4";
            label4.Size = new Size(139, 20);
            label4.TabIndex = 6;
            label4.Text = "Nombre de Usuario";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(365, 275);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 7;
            label5.Text = "Clave";
            label5.Click += label5_Click;
            // 
            // usuarioTextBox
            // 
            usuarioTextBox.Location = new Point(365, 230);
            usuarioTextBox.Margin = new Padding(3, 4, 3, 4);
            usuarioTextBox.Name = "usuarioTextBox";
            usuarioTextBox.Size = new Size(197, 27);
            usuarioTextBox.TabIndex = 8;
            // 
            // claveTextBox
            // 
            claveTextBox.Location = new Point(365, 299);
            claveTextBox.Margin = new Padding(3, 4, 3, 4);
            claveTextBox.Name = "claveTextBox";
            claveTextBox.Size = new Size(197, 27);
            claveTextBox.TabIndex = 9;
            claveTextBox.UseSystemPasswordChar = true;
            claveTextBox.TextChanged += textBox2_TextChanged;
            // 
            // registrarseButton
            // 
            registrarseButton.Location = new Point(365, 387);
            registrarseButton.Margin = new Padding(3, 4, 3, 4);
            registrarseButton.Name = "registrarseButton";
            registrarseButton.Size = new Size(198, 43);
            registrarseButton.TabIndex = 10;
            registrarseButton.Text = "Registrarse";
            registrarseButton.UseVisualStyleBackColor = true;
            registrarseButton.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F);
            label1.Location = new Point(319, 12);
            label1.Name = "label1";
            label1.Size = new Size(298, 62);
            label1.TabIndex = 11;
            label1.Text = "Crear Cuenta";
            label1.Click += label1_Click_1;
            // 
            // UsuarioRegistrar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 493);
            Controls.Add(label1);
            Controls.Add(registrarseButton);
            Controls.Add(claveTextBox);
            Controls.Add(usuarioTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(EmailLabel);
            Controls.Add(emailTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UsuarioRegistrar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            Load += UsuarioRegistrar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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