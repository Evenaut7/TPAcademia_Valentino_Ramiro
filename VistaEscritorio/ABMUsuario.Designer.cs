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
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsuario
            // 
            dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuario.Dock = DockStyle.Fill;
            dgvUsuario.Location = new Point(0, 0);
            dgvUsuario.Name = "dgvUsuario";
            dgvUsuario.Size = new Size(784, 461);
            dgvUsuario.TabIndex = 0;
            // 
            // eliminarButton
            // 
            eliminarButton.Dock = DockStyle.Right;
            eliminarButton.Location = new Point(704, 5);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(75, 30);
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
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(784, 40);
            // 
            // ABMUsuario
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(panel1);
            Controls.Add(dgvUsuario);
            Name = "ABMUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ABM Usuario";
            Load += ABMUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private DataGridView dgvUsuario;
        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private Button listarButton;
        private Panel panel1;
    }
}
