namespace VistaEscritorio
{
    partial class ABMUsuario
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
            dgvUsuario = new DataGridView();
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            listarButton = new Button();
            panel1 = new Panel();
            lblEstado = new Label();
            panel2 = new Panel();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsuario
            // 
            dgvUsuario.AllowUserToAddRows = false;
            dgvUsuario.AllowUserToDeleteRows = false;
            dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuario.Dock = DockStyle.Fill;
            dgvUsuario.Location = new Point(0, 61);
            dgvUsuario.MultiSelect = false;
            dgvUsuario.Name = "dgvUsuario";
            dgvUsuario.ReadOnly = true;
            dgvUsuario.RowHeadersWidth = 51;
            dgvUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuario.Size = new Size(784, 350);
            dgvUsuario.TabIndex = 0;
            dgvUsuario.SelectionChanged += dgvUsuario_SelectionChanged;
            // 
            // eliminarButton
            // 
            eliminarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            eliminarButton.Location = new Point(704, 8);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(75, 30);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            modificarButton.Location = new Point(623, 8);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(75, 30);
            modificarButton.TabIndex = 2;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            agregarButton.Location = new Point(542, 8);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(75, 30);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // listarButton
            // 
            listarButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            listarButton.Location = new Point(461, 8);
            listarButton.Name = "listarButton";
            listarButton.Size = new Size(75, 30);
            listarButton.TabIndex = 0;
            listarButton.Text = "Listar";
            listarButton.UseVisualStyleBackColor = true;
            listarButton.Click += listarButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblEstado);
            panel1.Controls.Add(listarButton);
            panel1.Controls.Add(agregarButton);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(eliminarButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 411);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(784, 50);
            panel1.TabIndex = 0;
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(13, 17);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 15);
            lblEstado.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(lblTitulo);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(784, 61);
            panel2.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Usuarios";
            // 
            // ABMUsuario
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(dgvUsuario);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ABMUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ABM Usuario";
            Load += ABMUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvUsuario;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private Button listarButton;
        private Panel panel1;
        private Label lblEstado;
        private Panel panel2;
        private Label lblTitulo;
    }
}