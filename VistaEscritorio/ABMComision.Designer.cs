namespace VistaEscritorio
{
    partial class ABMComision
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
            dgvComision = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            listarButton = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvComision).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvComision
            // 
            dgvComision.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComision.Dock = DockStyle.Fill;
            dgvComision.Location = new Point(0, 0);
            dgvComision.Name = "dgvComision";
            dgvComision.Size = new Size(784, 461);
            dgvComision.TabIndex = 0;
            // 
            // eliminarButton
            // 
            eliminarButton.Dock = DockStyle.Right;
            eliminarButton.Location = new Point(704, 5);
            eliminarButton.Margin = new Padding(20);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(75, 30);
            eliminarButton.TabIndex = 0;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Dock = DockStyle.Right;
            modificarButton.Location = new Point(629, 5);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(75, 30);
            modificarButton.TabIndex = 1;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Dock = DockStyle.Right;
            agregarButton.Location = new Point(554, 5);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(75, 30);
            agregarButton.TabIndex = 2;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // listarButton
            // 
            listarButton.Dock = DockStyle.Right;
            listarButton.Location = new Point(479, 5);
            listarButton.Name = "listarButton";
            listarButton.Size = new Size(75, 30);
            listarButton.TabIndex = 3;
            listarButton.Text = "Listar";
            listarButton.UseVisualStyleBackColor = true;
            listarButton.Click += listarButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(listarButton);
            panel1.Controls.Add(agregarButton);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(eliminarButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 421);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(784, 40);
            panel1.TabIndex = 3;
            // 
            // ABMComision
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(panel1);
            Controls.Add(dgvComision);
            Name = "ABMComision";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ABMComision";
            Load += ABMComision_Load;
            ((System.ComponentModel.ISupportInitialize)dgvComision).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvComision;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private Button listarButton;
        private Panel panel1;
    }
}