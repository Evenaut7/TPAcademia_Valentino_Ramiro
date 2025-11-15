namespace VistaEscritorio
{
    partial class ABMPersona
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Button listarButton;
        public System.Windows.Forms.Button agregarButton;
        public System.Windows.Forms.Button modificarButton;
        public System.Windows.Forms.Button eliminarButton;

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
            listarButton = new Button();
            agregarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            panel1 = new Panel();
            dgvPersonas = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            SuspendLayout();
            // 
            // listarButton
            // 
            listarButton.Dock = DockStyle.Right;
            listarButton.Location = new Point(479, 5);
            listarButton.Name = "listarButton";
            listarButton.Size = new Size(75, 30);
            listarButton.TabIndex = 6;
            listarButton.Text = "Listar";
            listarButton.UseVisualStyleBackColor = true;
            listarButton.Click += listarButton_Click;
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
            // modificarButton
            // 
            modificarButton.Dock = DockStyle.Right;
            modificarButton.Location = new Point(629, 5);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(75, 30);
            modificarButton.TabIndex = 3;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Dock = DockStyle.Right;
            eliminarButton.Location = new Point(704, 5);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(75, 30);
            eliminarButton.TabIndex = 4;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(listarButton);
            panel1.Controls.Add(agregarButton);
            panel1.Controls.Add(modificarButton);
            panel1.Controls.Add(eliminarButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 421);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(784, 40);
            panel1.TabIndex = 5;
            // 
            // dgvPersonas
            // 
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Dock = DockStyle.Fill;
            dgvPersonas.Location = new Point(0, 0);
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.Size = new Size(784, 421);
            dgvPersonas.TabIndex = 6;
            dgvPersonas.CellContentClick += dgvPersonas_CellContentClick;
            // 
            // ABMPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(dgvPersonas);
            Controls.Add(panel1);
            Name = "ABMPersona";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ABM Persona";
            Load += ABMPersona_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            ResumeLayout(false);
        }

        private Panel panel1;
        private DataGridView dgvPersonas;
    }
}