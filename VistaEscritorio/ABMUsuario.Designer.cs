namespace VistaEscritorio
{
    partial class ABMUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvUsuarios;
        private Button listarButton;
        private Button agregarButton;
        private Button eliminarButton;
        private Button modificarButton;
        private Panel panel1;

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
            dgvUsuarios = new DataGridView();
            panel1 = new Panel();
            listarButton = new Button();
            agregarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Dock = DockStyle.Top;
            dgvUsuarios.Location = new Point(0, 0);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(680, 150);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(listarButton);
            panel1.Controls.Add(agregarButton);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(eliminarButton);
            panel1.Location = new Point(335, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(329, 40);
            panel1.TabIndex = 3;
            // 
            // listarButton
            // 
            listarButton.Dock = DockStyle.Right;
            listarButton.Location = new Point(29, 0);
            listarButton.Name = "listarButton";
            listarButton.Size = new Size(75, 40);
            listarButton.TabIndex = 0;
            listarButton.Text = "Listar";
            listarButton.Click += listarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Dock = DockStyle.Right;
            agregarButton.Location = new Point(104, 0);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(75, 40);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.Click += agregarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Dock = DockStyle.Right;
            modificarButton.Location = new Point(179, 0);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(75, 40);
            modificarButton.TabIndex = 2;
            modificarButton.Text = "Modificar";
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Dock = DockStyle.Right;
            eliminarButton.Location = new Point(254, 0);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(75, 40);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.Click += eliminarButton_Click;
            // 
            // ABMUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 244);
            Controls.Add(panel1);
            Controls.Add(dgvUsuarios);
            Name = "ABMUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ABM Usuarios";
            Load += UsuarioABM_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
