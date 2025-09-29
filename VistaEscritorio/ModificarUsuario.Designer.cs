using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace VistaEscritorio
{
    partial class ModificarUsuario
    {
        private System.ComponentModel.IContainer components = null;

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
            emailTextBox = new TextBox();
            usuarioTextBox = new TextBox();
            claveTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            modificarButton = new Button();
            cancelarButton = new Button();
            SuspendLayout();
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(137, 25);
            emailTextBox.Margin = new Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(228, 27);
            emailTextBox.TabIndex = 2;
            // 
            // usuarioTextBox
            // 
            usuarioTextBox.Location = new Point(137, 79);
            usuarioTextBox.Margin = new Padding(3, 4, 3, 4);
            usuarioTextBox.Name = "usuarioTextBox";
            usuarioTextBox.Size = new Size(228, 27);
            usuarioTextBox.TabIndex = 3;
            // 
            // claveTextBox
            // 
            claveTextBox.Location = new Point(137, 132);
            claveTextBox.Margin = new Padding(3, 4, 3, 4);
            claveTextBox.Name = "claveTextBox";
            claveTextBox.PasswordChar = '*';
            claveTextBox.Size = new Size(228, 27);
            claveTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 29);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 7;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 83);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 8;
            label4.Text = "Usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 136);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 9;
            label5.Text = "Clave";
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(136, 196);
            modificarButton.Margin = new Padding(3, 4, 3, 4);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(86, 31);
            modificarButton.TabIndex = 10;
            modificarButton.Text = "Modificar";
            modificarButton.Click += modificarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(279, 196);
            cancelarButton.Margin = new Padding(3, 4, 3, 4);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(86, 31);
            cancelarButton.TabIndex = 11;
            cancelarButton.Text = "Cancelar";
            cancelarButton.Click += cancelarButton_Click;
            // 
            // ModificarUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 254);
            Controls.Add(emailTextBox);
            Controls.Add(usuarioTextBox);
            Controls.Add(claveTextBox);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(modificarButton);
            Controls.Add(cancelarButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ModificarUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Usuario";
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox emailTextBox;
        private TextBox usuarioTextBox;
        private TextBox claveTextBox;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button modificarButton;
        private Button cancelarButton;
    }
}
