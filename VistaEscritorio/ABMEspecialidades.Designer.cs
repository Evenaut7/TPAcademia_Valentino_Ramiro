namespace VistaEscritorio
{
    partial class ABMEspecialidades
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
            dgvEspecialidades = new DataGridView();
            panel1 = new Panel();
            listarButton = new Button();
            agregarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEspecialidades
            // 
            dgvEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEspecialidades.Dock = DockStyle.Top;
            dgvEspecialidades.Location = new Point(0, 0);
            dgvEspecialidades.Margin = new Padding(30);
            dgvEspecialidades.Name = "dgvEspecialidades";
            dgvEspecialidades.Size = new Size(550, 150);
            dgvEspecialidades.TabIndex = 1;
            dgvEspecialidades.CellContentClick += dgvEspecialidades_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(listarButton);
            panel1.Controls.Add(agregarButton);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(eliminarButton);
            panel1.Location = new Point(221, 179);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 2, 10, 2);
            panel1.Size = new Size(329, 40);
            panel1.TabIndex = 2;
            // 
            // listarButton
            // 
            listarButton.Dock = DockStyle.Right;
            listarButton.Location = new Point(19, 2);
            listarButton.Name = "listarButton";
            listarButton.Size = new Size(75, 36);
            listarButton.TabIndex = 3;
            listarButton.Text = "Listar";
            listarButton.UseVisualStyleBackColor = true;
            listarButton.Click += listarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Dock = DockStyle.Right;
            agregarButton.Location = new Point(94, 2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(75, 36);
            agregarButton.TabIndex = 2;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Dock = DockStyle.Right;
            modificarButton.Location = new Point(169, 2);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(75, 36);
            modificarButton.TabIndex = 1;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Dock = DockStyle.Right;
            eliminarButton.Location = new Point(244, 2);
            eliminarButton.Margin = new Padding(20);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(75, 36);
            eliminarButton.TabIndex = 0;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // ABMEspecialidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 238);
            Controls.Add(panel1);
            Controls.Add(dgvEspecialidades);
            Name = "ABMEspecialidades";
            Text = "ABM Especialidades";
            Load += ABMEspecialidades_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEspecialidades;
        private Panel panel1;
        private Button listarButton;
        private Button agregarButton;
        private Button modificarButton;
        private Button eliminarButton;
    }
}