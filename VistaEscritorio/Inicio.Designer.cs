namespace VistaEscritorio
{
    partial class Inicio
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
            tituloInicio = new Label();
            inicioSesionButton = new Button();
            usuarioTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // tituloInicio
            // 
            tituloInicio.AutoSize = true;
            tituloInicio.Font = new Font("Yu Gothic UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tituloInicio.ImageAlign = ContentAlignment.TopCenter;
            tituloInicio.Location = new Point(217, 45);
            tituloInicio.Name = "tituloInicio";
            tituloInicio.RightToLeft = RightToLeft.Yes;
            tituloInicio.Size = new Size(404, 50);
            tituloInicio.TabIndex = 0;
            tituloInicio.Text = "Autogestion Academia";
            tituloInicio.TextAlign = ContentAlignment.TopCenter;
            // 
            // inicioSesionButton
            // 
            inicioSesionButton.Location = new Point(325, 289);
            inicioSesionButton.Name = "inicioSesionButton";
            inicioSesionButton.Size = new Size(151, 23);
            inicioSesionButton.TabIndex = 2;
            inicioSesionButton.Text = "Iniciar Sesion";
            inicioSesionButton.UseVisualStyleBackColor = true;
            inicioSesionButton.Click += button1_Click;
            // 
            // usuarioTextBox
            // 
            usuarioTextBox.Location = new Point(291, 190);
            usuarioTextBox.Name = "usuarioTextBox";
            usuarioTextBox.Size = new Size(225, 23);
            usuarioTextBox.TabIndex = 3;
            usuarioTextBox.Tag = "Usuario";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(291, 244);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(225, 23);
            passwordTextBox.TabIndex = 4;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(291, 172);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 5;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(291, 226);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 6;
            label3.Text = "Contraseña";
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tituloInicio);
            Controls.Add(passwordTextBox);
            Controls.Add(usuarioTextBox);
            Controls.Add(inicioSesionButton);
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Academia";
            Load += Inicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Label inicioTitle;
        private TextBox usuarioTextBox;
        private Label tituloInicio;
        private Button inicioSesionButton;
        private TextBox passwordTextBox;
    }
}