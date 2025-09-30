namespace VistaEscritorio
{
    partial class ABMCurso
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
            dgvCurso = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            listarButton = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvCurso).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCurso
            // 
            dgvCurso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurso.Dock = DockStyle.Top;
            dgvCurso.Location = new Point(0, 0);
            dgvCurso.Name = "dgvCurso";
            dgvCurso.Size = new Size(680, 150);
            dgvCurso.TabIndex = 0;
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
            eliminarButton.Click += eliminarButton_Click_1;
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
            // listarButton
            // 
            listarButton.Dock = DockStyle.Right;
            listarButton.Location = new Point(19, 2);
            listarButton.Name = "listarButton";
            listarButton.Size = new Size(75, 36);
            listarButton.TabIndex = 3;
            listarButton.Text = "Listar";
            listarButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(listarButton);
            panel1.Controls.Add(agregarButton);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(eliminarButton);
            panel1.Location = new Point(335, 185);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 2, 10, 2);
            panel1.Size = new Size(329, 40);
            panel1.TabIndex = 3;
            // 
            // ABMCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 244);
            Controls.Add(panel1);
            Controls.Add(dgvCurso);
            Name = "ABMCurso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ABMCruso";
            Load += ABMCurso_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCurso).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCurso;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private Button listarButton;
        private Panel panel1;
    }
}